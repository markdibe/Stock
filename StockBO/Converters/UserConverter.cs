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
            UserBO userBo = new UserBO()
            {
                Email = user.Email,
                Password = user.Password,
                UserId = user.UserId,
                UserName = user.UserName
            };
            return userBo;
        }

        public User Convert(UserBO userBo)
        {
            User user = new User
            {
                Email = userBo.Email,
                UserName = userBo.UserName,
                UserId = userBo.UserId,
                Password = userBo.Password
            };
            return user;
        }
    }
}
