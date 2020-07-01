using StockBO.BO;
using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockBO.IServices
{
    public interface IUserService
    {
        Task<UserBO> Create(UserBO user);

        Task<UserBO> Delete(string id);

        Task<UserBO> GetById(string id);

        Task<ICollection<UserBO>> Get();

        Task<UserBO> Update(UserBO updatedUserBo);

        Task<bool> IsCorrectLogin(UserBO user);

    }
}
