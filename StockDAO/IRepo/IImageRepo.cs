using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockDAO.IRepo
{
    public interface IImageRepo
    {
        Image Create(Image image);

        Image Delete(string id);

        Image GetById(string id);

        ICollection<Image> Get();
    }
}
