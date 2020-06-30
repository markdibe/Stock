using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockDAO.IRepo
{
    public interface IItemImageRepo
    {
        ItemImages Create(ItemImages itemImages);

        ItemImages GetById(string id);

        ICollection<ItemImages> Get();

        ItemImages Delete(string id);
    }
}
