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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Personal Data

            modelBuilder.Entity<County>(entity =>
            {
                entity.HasKey(c => c.ID);
                entity.Property(c => c.Name).HasMaxLength(50);
            });

            //Il Country è stato definito con le DataAnnotation

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(c => c.Name)
                    .HasName("Customer_Name_Index");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasIndex(c => c.Description)
                    .HasName("Item Description Index");
                entity.Property(c => c.Inventory)
                    .HasColumnType("decimal(18,2)");
                entity.Property(c => c.No)
                    .HasColumnType("varchar(20)");
                entity.Property(c => c.Description)
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");
                entity.Property(c => c.UnitPrice)
                    .HasColumnType("money")
                    .HasColumnName("Unit Price");
            });

            #endregion

            #region Sales

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(o => o.Date)
                    .HasColumnType("datetime");

                entity.Property(o => o.No)
                    .HasColumnType("varchar(20)")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                //Chiave primaria multipla può essere definita solo con le API
                entity.HasKey(ol => new { ol.OrderId, ol.Id });

                //Definizione del tipo di campo per SQL Server e valore di default
                entity.Property(ol => ol.Quantity)
                    .HasColumnType("decimal(18,2)");

                entity.Property(ol => ol.UnitPrice)
                    .HasColumnType("money")
                    .HasColumnName("Unit Price");

                entity.Property(ol => ol.LineAmount)
                    .HasColumnType("money")
                    .HasColumnName("Line Amount");

                entity.Property(ol => ol.LineNo)
                    .HasColumnType("int")
                    .HasColumnName("Line No");
            });

            #endregion
        }
    }
}
