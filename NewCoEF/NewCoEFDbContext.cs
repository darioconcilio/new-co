using Microsoft.EntityFrameworkCore;
using NewCoEF.Areas.PersonalData.Models;
using NewCoEF.Areas.Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF
{
    public class NewCoEFDbContext : DbContext
    {
        public NewCoEFDbContext(DbContextOptions<NewCoEFDbContext> opt) : base(opt)
        {

        }

        #region Personal Data

        public DbSet<County> Counties { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }

        #endregion

        #region Sales

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
