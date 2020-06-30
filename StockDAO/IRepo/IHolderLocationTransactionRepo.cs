using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockDAO.IRepo
{
    public interface IHolderLocationTransactionRepo
    {
        HolderLocationTransaction Create(HolderLocationTransaction holderLocationTransaction);

        HolderLocationTransaction Delete(string id);

        HolderLocationTransaction GetById(string id);

        ICollection<HolderLocationTransaction> Get();
    }
}
