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
                uow.UserRepo.Create(newUser);
                uow.complete();
                return converter.Convert(newUser) ;
            }
        }

        public UserBO Delete(string id)
        {
            using(var uow = _facade.unitOfWork)
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
            using(var uow = _facade.unitOfWork)
            {
                User UserDb = uow.UserRepo.GetById(updatedUserBo.UserId);
                UserDb.UserName = updatedUserBo.UserName;
                UserDb.Password = updatedUserBo.Password;
                UserDb.Email = updatedUserBo.Email;
                uow.complete();
                return converter.Convert(UserDb);
            }
        }
    }
}
