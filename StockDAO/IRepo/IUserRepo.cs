using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockDAO.IRepo
{
    public interface IUserRepo
    {
        Task<User> Create(User user);

        Task<User> Delete(string id);

        Task<User> GetById(string id);

        Task<ICollection<User>> Get();

        Task<bool> IsCorrectLogin(User user);
    }
}
