using StockBO.BO;
using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockBO.IServices
{
    public interface IUserService
    {
        UserBO Create(UserBO user);

        UserBO Delete(string id);

        UserBO GetById(string id);

        ICollection<UserBO> Get();

        UserBO Update(UserBO updatedUserBo);
    }
}
