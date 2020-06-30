using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockDAO.IRepo
{
    public interface ICategoryRepo
    {
        Category Create(Category category);

        Category Delete(Int64 Id);

        Category GetById(Int64 Id);

        ICollection<Category> Get();
   
    }
}
