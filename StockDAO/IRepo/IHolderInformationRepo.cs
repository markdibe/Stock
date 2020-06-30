using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockDAO.IRepo
{
    public interface IHolderInformationRepo
    {
        HolderInformation Create(HolderInformation holder);

        HolderInformation Delete(Int64 id);

        HolderInformation GetById(Int64 id);

        ICollection<HolderInformation> Get();
    }
}
