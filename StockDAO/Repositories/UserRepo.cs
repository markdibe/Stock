using StockDAO.Context;
using StockDAO.Entities;
using StockDAO.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockDAO.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly StockContext _context;


        public UserRepo(StockContext context)
        {
            _context = context;
        }
        public User Create(User user)
        {
            _context.Users.Add(user);
            return user;
        }

        public User Delete(string id)
        {
            User user = GetById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            return user;
        }

        public ICollection<User> Get()
        {
            return _context.Users.ToList();
        }

        public User GetById(string id)
        {
            return _context.Users.FirstOrDefault(x => x.UserId.Equals(id));
        }
    }
}
