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
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<HolderImages> HolderImages { get; set; }
        public virtual DbSet<HolderInformation> HolderInformations { get; set; }

        public virtual DbSet<HolderLocationTransaction> HolderLocationTransactions { get; set; }

        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<ItemImages> ItemImages { get; set; }

        public virtual DbSet<ItemLocationTransaction> ItemLocationTransactions { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<Store> Stores { get; set; }

        public virtual DbSet<Title> Titles { get; set; }

        
    
    }
}
