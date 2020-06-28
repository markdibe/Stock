using StockDAO.IRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockDAO
{
    public interface IUnitOfWork :IDisposable
    {
        int complete();
        IUserRepo UserRepo { get; set; }
    }
}
