using Microsoft.EntityFrameworkCore;
using NewCoEF.Areas.PersonalData.Models;
using NewCoEF.Areas.Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF
{
    public partial class NewCoEFDbContext : DbContext
    {
        public NewCoEFDbContext()
        {
        }

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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasIndex(e => e.Description)
                    .HasName("Item Description Index");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Inventory).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.No)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("Unit Price")
                    .HasColumnType("money");
            });

        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<County>(entity =>
            {
                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(22);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.CountryRefId);

                entity.HasIndex(e => e.CountyRefId);

                entity.HasIndex(e => e.Name)
                    .HasName("Customer_Name_Index");

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryRefId).HasColumnName("CountryRefID");

                entity.Property(e => e.CountyRefId).HasColumnName("CountyRefID");

                entity.Property(e => e.VATRegistrationCode).HasColumnName("VATRegistrationCode");

                entity.HasOne(d => d.CountryRef)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CountryRefId);

                entity.HasOne(d => d.CountyRef)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CountyRefId);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasIndex(e => e.Description)
                    .HasName("Item Description Index");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Inventory).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.No)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("Unit Price")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<OrderLines>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.Id });

                entity.HasIndex(e => e.ItemRefId);

                entity.Property(e => e.LineAmount)
                    .HasColumnName("Line Amount")
                    .HasColumnType("money");

                entity.Property(e => e.LineNo).HasColumnName("Line No");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("Unit Price")
                    .HasColumnType("money");

                entity.HasOne(d => d.ItemRef)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.ItemRefId);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerRefId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomerRefId).HasColumnName("CustomerRefID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.No)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustomerRef)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerRefId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);*/
    }
}
