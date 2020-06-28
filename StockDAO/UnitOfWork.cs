using StockDAO.Context;
using StockDAO.IRepo;
using StockDAO.Repositories;
using System;

namespace StockDAO
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StockContext _context;
        public IUserRepo UserRepo { get;  set; }
        public UnitOfWork(StockContext context)
        {
            _context = context;
            UserRepo = new UserRepo(_context);       
        }

        public int complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
