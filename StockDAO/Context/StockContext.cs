using Microsoft.EntityFrameworkCore;
using StockDAO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockDAO.Context
{
    public class StockContext :DbContext
    {
        public StockContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }

    }
}
