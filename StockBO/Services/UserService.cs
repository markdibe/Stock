using StockBO.BO;
using StockBO.Converters;
using StockBO.IServices;
using StockDAO;
using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<UserBO> Create(UserBO user)
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
                    await uow.UserRepo.Create(newUser);
                    uow.complete();
                    return user;
                }
            }
            return null;
        }

        public async Task<UserBO> Delete(string id)
        {
            using (var uow = _facade.unitOfWork)
            {
                User user = await uow.UserRepo.Delete(id);
                uow.complete();
                return converter.Convert(user);
            }
        }

        public async Task<ICollection<UserBO>> Get()
        {
            using (var uow = _facade.unitOfWork)
            {
                var list = await uow.UserRepo.Get();
                return list.Select(u => converter.Convert(u)).ToList();
            }
        }

        public async Task<UserBO> GetById(string id)
        {
            using (var uow = _facade.unitOfWork)
            {
                return converter.Convert(await uow.UserRepo.GetById(id));
            }
        }

        public async Task<UserBO> Update(UserBO updatedUserBo)
        {
            using (var uow = _facade.unitOfWork)
            {
                User UserDb = await uow.UserRepo.GetById(updatedUserBo.UserId);
                UserDb.UserName = updatedUserBo.UserName;
                UserDb.Password = updatedUserBo.Password;
                UserDb.Email = updatedUserBo.Email;
                uow.complete();
                return converter.Convert(UserDb);
            }
        }

        public async Task<bool> IsCorrectLogin(UserBO user)
        {

            if (GetByEmail(user) != null)
            {
                string encriptionKey = GetByEmail(user).Result.EncriptionKey;
                string encriptInputPassword = StringCipher.Encrypt(user.Password, encriptionKey);
                user.Password = encriptInputPassword;
                using (var uow = _facade.unitOfWork)
                {
                    return await uow.UserRepo.IsCorrectLogin(converter.Convert(user));
                }
            }
            return false;
        }

        public async Task<UserBO> GetByEmail(UserBO user)
        {
            using (var uow = _facade.unitOfWork)
            {
                return   converter.Convert(  uow.UserRepo.Get()
                    .Result.FirstOrDefault(x =>
                x.Email.Trim().
                ToLower().
                Equals(user.Email.Trim().ToLower())));
                //return converter.Convert(list.FirstOrDefault(x => x.Email.Trim().ToLower().Equals(user.Email.Trim().ToLower())));
            }
        }


    }
}
