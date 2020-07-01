using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockDAO.IRepo
{
    public interface IItemImageRepo
    {
       Task<ItemImages> Create(ItemImages itemImages);

        Task<ItemImages> GetById(string id);

        Task<ICollection<ItemImages>> Get();

        Task<ItemImages> Delete(string id);
    }
}
