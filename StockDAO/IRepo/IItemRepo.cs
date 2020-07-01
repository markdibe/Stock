using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockDAO.IRepo
{
    public interface IItemRepo
    {
        Task<Item>  Create(Item item);

        Task<ICollection<Item>> Get();

        Task<Item> Delete(string id);

        Task<Item> GetById(string id);
    }
}
