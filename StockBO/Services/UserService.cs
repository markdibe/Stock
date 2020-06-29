using StockBO.BO;
using StockBO.Converters;
using StockBO.IServices;
using StockDAO;
using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockBO.Services
{
    public class UserService : IUserService
    {
        public UserConverter converter;
        private readonly FacadeDAO _facade;

        public UserService(FacadeDAO facade)
        {
            _facade = facade;
            converter = new UserConverter();
        }
        public UserBO Create(UserBO user)
        {
            using (var uow = _facade.unitOfWork)
            {
                User newUser = converter.Convert(user);
                //saving password inside database as encripted code  and save the key of encription
                if (GetByEmail(user) == null)
                {
                    //generate a special encription key for the user and save it 
                    newUser.EncriptionKey = Guid.NewGuid().ToString();
                    // encript password and save it into db as encripted
                    newUser.Password = StringCipher.Encrypt(newUser.Password, newUser.EncriptionKey);
                    uow.UserRepo.Create(newUser);
                    uow.complete();
                    return converter.Convert(newUser);
                }
            }
            return null;
        }

        public UserBO Delete(string id)
        {
            using (var uow = _facade.unitOfWork)
            {
                User user = uow.UserRepo.Delete(id);
                uow.complete();
                return converter.Convert(user);
            }
        }

        public ICollection<UserBO> Get()
        {
            using (var uow = _facade.unitOfWork)
            {
                return uow.UserRepo.Get()
                    .Select(u => converter.Convert(u))
                    .ToList();
            }
        }

        public UserBO GetById(string id)
        {
            using (var uow = _facade.unitOfWork)
            {
                return converter.Convert(uow.UserRepo.GetById(id));
            }

        }

        public UserBO Update(UserBO updatedUserBo)
        {
            using (var uow = _facade.unitOfWork)
            {
                User UserDb = uow.UserRepo.GetById(updatedUserBo.UserId);
                UserDb.UserName = updatedUserBo.UserName;
                UserDb.Password = updatedUserBo.Password;
                UserDb.Email = updatedUserBo.Email;
                uow.complete();
                return converter.Convert(UserDb);
            }
        }

        public bool IsCorrectLogin(UserBO user)
        {

            if (GetByEmail(user) != null)
            {
                string encriptionKey = GetByEmail(user).EncriptionKey;
                string encriptInputPassword = StringCipher.Encrypt(user.Password, encriptionKey);
                user.Password = encriptInputPassword;
                using (var uow = _facade.unitOfWork)
                {
                    return uow.UserRepo.IsCorrectLogin(converter.Convert(user));
                }
            }
            return false;
        }

        public UserBO GetByEmail(UserBO user)
        {
            using (var uow = _facade.unitOfWork)
            {
                return converter.Convert(uow.UserRepo.Get().FirstOrDefault(x => x.Email.Trim().ToLower().Equals(user.Email.Trim().ToLower())));
            }
        }


    }
}
