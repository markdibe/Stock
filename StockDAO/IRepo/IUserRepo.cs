using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockDAO.IRepo
{
    public interface IUserRepo
    {
        User Create(User user);

        User Delete(string id);

        User GetById(string id);

        ICollection<User> Get();
    }
}
