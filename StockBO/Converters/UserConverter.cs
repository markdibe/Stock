using StockBO.BO;
using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockBO.Converters
{
    public class UserConverter
    {
        public UserBO Convert(User user)
        {
            if (user != null)
            {
                UserBO userBo = new UserBO()
                {
                    Email = user.Email,
                    Password = user.Password,
                    UserId = user.UserId,
                    UserName = user.UserName,
                    EncriptionKey = user.EncriptionKey
                };
                return userBo;
            }
            return null;
        }

        public User Convert(UserBO userBo)
        {
            if (userBo != null)
            {
                User user = new User
                {
                    Email = userBo.Email,
                    UserName = userBo.UserName,
                    UserId = userBo.UserId,
                    Password = userBo.Password,
                    EncriptionKey = userBo.EncriptionKey
                };
                return user;
            }
            return null;
        }
    }
}
