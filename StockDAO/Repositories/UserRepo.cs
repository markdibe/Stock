using Microsoft.EntityFrameworkCore;
using StockDAO.Context;
using StockDAO.Entities;
using StockDAO.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDAO.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly StockContext _context;


        public UserRepo(StockContext context)
        {
            _context = context;
        }
        public async Task<User> Create(User user)
        {
            await _context.Users.AddAsync(user);
            return user;
        }

        public async Task<User> Delete(string id)
        {
            User user = await GetById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            return user;
        }

        public async Task<ICollection<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserId.Equals(id));
        }

        public async Task<bool> IsCorrectLogin(User user)
        {
            bool existed = await _context.Users.AnyAsync(x =>
            x.Email.ToLower().Trim().Equals(user.Email.ToLower().Trim())
            && x.Password.Equals(user.Password)
            );
            return existed;
        }

    }
}
