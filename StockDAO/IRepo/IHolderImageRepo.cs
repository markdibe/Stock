using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockDAO.IRepo
{
    public interface IHolderImageRepo
    {
        HolderImages GetById(string Id);

        ICollection<HolderImages> Get();

        HolderImages Create(HolderImages holderImage);

        HolderImages Delete(string id);
    

    }
}
