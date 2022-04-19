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
    [Migration("20220412062601_newdata")]
    partial class newdata
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

                    b.Property<Guid?>("CountryRefId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CountyRefId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VATRegistrationCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CountryRefId");

                    b.HasIndex("CountyRefId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("NewCoEF.Areas.PersonalData.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Inventory")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("No")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("NewCoEF.Areas.Sales.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerRefId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("No")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerRefId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("NewCoEF.Areas.Sales.Models.OrderLines", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ItemRefId")
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

                    b.HasIndex("ItemRefId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("NewCoEF.Areas.PersonalData.Models.Customer", b =>
                {
                    b.HasOne("NewCoEF.Areas.PersonalData.Models.Country", "CountryRef")
                        .WithMany("Customers")
                        .HasForeignKey("CountryRefId");

                    b.HasOne("NewCoEF.Areas.PersonalData.Models.County", "CountyRef")
                        .WithMany("Customers")
                        .HasForeignKey("CountyRefId");
                });

            modelBuilder.Entity("NewCoEF.Areas.Sales.Models.Order", b =>
                {
                    b.HasOne("NewCoEF.Areas.PersonalData.Models.Customer", "CustomerRef")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NewCoEF.Areas.Sales.Models.OrderLines", b =>
                {
                    b.HasOne("NewCoEF.Areas.PersonalData.Models.Item", "ItemRef")
                        .WithMany("OrderLines")
                        .HasForeignKey("ItemRefId");

                    b.HasOne("NewCoEF.Areas.Sales.Models.Order", "Order")
                        .WithMany("Lines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}