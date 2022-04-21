﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewCoEF;

namespace NewCoEF.Migrations
{
    [DbContext(typeof(NewCoEFDbContext))]
    [Migration("20220421063555_PrimaryKey")]
    partial class PrimaryKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NewCoEF.Areas.PersonalData.Models.Country", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(22)")
                        .HasMaxLength(22);

                    b.HasKey("ID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("NewCoEF.Areas.PersonalData.Models.County", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Counties");
                });

            modelBuilder.Entity("NewCoEF.Areas.PersonalData.Models.Customer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CountyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VATRegistrationCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CountryId");

                    b.HasIndex("CountyId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("NewCoEF.Areas.PersonalData.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<decimal>("Inventory")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("No")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<decimal>("UnitPrice")
                        .HasColumnName("Unit Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("Description")
                        .HasName("Item Description Index");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("NewCoEF.Areas.Sales.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("No")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("NewCoEF.Areas.Sales.Models.OrderLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LineAmount")
                        .HasColumnType("float");

                    b.Property<int>("LineNo")
                        .HasColumnType("int");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("NewCoEF.Areas.PersonalData.Models.Customer", b =>
                {
                    b.HasOne("NewCoEF.Areas.PersonalData.Models.Country", "CountryRef")
                        .WithMany("Customers")
                        .HasForeignKey("CountryId");

                    b.HasOne("NewCoEF.Areas.PersonalData.Models.County", "CountyRef")
                        .WithMany("Customers")
                        .HasForeignKey("CountyId");
                });

            modelBuilder.Entity("NewCoEF.Areas.Sales.Models.Order", b =>
                {
                    b.HasOne("NewCoEF.Areas.PersonalData.Models.Customer", "CustomerRef")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewCoEF.Areas.Sales.Models.OrderLine", b =>
                {
                    b.HasOne("NewCoEF.Areas.PersonalData.Models.Item", "ItemRef")
                        .WithMany("OrderLines")
                        .HasForeignKey("ItemId");

                    b.HasOne("NewCoEF.Areas.Sales.Models.Order", "OrderRef")
                        .WithMany("Lines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
