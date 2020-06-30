using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockDAO.IRepo
{
    public interface IItemRepo
    {
        Item Create(Item item);

        ICollection<Item> Get();

        Item Delete(string id);

        Item GetById(string id);
    }
}
