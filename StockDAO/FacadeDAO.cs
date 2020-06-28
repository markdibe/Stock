using StockDAO.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockDAO
{
    public class FacadeDAO
    {
        public  IUnitOfWork unitOfWork { get; set; }
        private StockContext _context;

        public FacadeDAO(StockContext context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(context);
        }
    }
}
