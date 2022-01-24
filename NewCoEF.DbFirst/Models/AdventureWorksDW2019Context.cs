using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class AdventureWorksDW2019Context : DbContext
    {
        public AdventureWorksDW2019Context()
        {
        }

        public AdventureWorksDW2019Context(DbContextOptions<AdventureWorksDW2019Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AdventureWorksDwbuildVersion> AdventureWorksDwbuildVersion { get; set; }
        public virtual DbSet<DatabaseLog> DatabaseLog { get; set; }
        public virtual DbSet<DimAccount> DimAccount { get; set; }
        public virtual DbSet<DimCurrency> DimCurrency { get; set; }
        public virtual DbSet<DimCustomer> DimCustomer { get; set; }
        public virtual DbSet<DimDate> DimDate { get; set; }
        public virtual DbSet<DimDepartmentGroup> DimDepartmentGroup { get; set; }
        public virtual DbSet<DimEmployee> DimEmployee { get; set; }
        public virtual DbSet<DimGeography> DimGeography { get; set; }
        public virtual DbSet<DimOrganization> DimOrganization { get; set; }
        public virtual DbSet<DimProduct> DimProduct { get; set; }
        public virtual DbSet<DimProductCategory> DimProductCategory { get; set; }
        public virtual DbSet<DimProductSubcategory> DimProductSubcategory { get; set; }
        public virtual DbSet<DimPromotion> DimPromotion { get; set; }
        public virtual DbSet<DimReseller> DimReseller { get; set; }
        public virtual DbSet<DimSalesReason> DimSalesReason { get; set; }
        public virtual DbSet<DimSalesTerritory> DimSalesTerritory { get; set; }
        public virtual DbSet<DimScenario> DimScenario { get; set; }
        public virtual DbSet<FactAdditionalInternationalProductDescription> FactAdditionalInternationalProductDescription { get; set; }
        public virtual DbSet<FactCallCenter> FactCallCenter { get; set; }
        public virtual DbSet<FactCurrencyRate> FactCurrencyRate { get; set; }
        public virtual DbSet<FactFinance> FactFinance { get; set; }
        public virtual DbSet<FactInternetSales> FactInternetSales { get; set; }
        public virtual DbSet<FactInternetSalesReason> FactInternetSalesReason { get; set; }
        public virtual DbSet<FactProductInventory> FactProductInventory { get; set; }
        public virtual DbSet<FactResellerSales> FactResellerSales { get; set; }
        public virtual DbSet<FactSalesQuota> FactSalesQuota { get; set; }
        public virtual DbSet<FactSurveyResponse> FactSurveyResponse { get; set; }
        public virtual DbSet<NewFactCurrencyRate> NewFactCurrencyRate { get; set; }
        public virtual DbSet<ProspectiveBuyer> ProspectiveBuyer { get; set; }
        public virtual DbSet<VAssocSeqLineItems> VAssocSeqLineItems { get; set; }
        public virtual DbSet<VAssocSeqOrders> VAssocSeqOrders { get; set; }
        public virtual DbSet<VDmprep> VDmprep { get; set; }
        public virtual DbSet<VTargetMail> VTargetMail { get; set; }
        public virtual DbSet<VTimeSeries> VTimeSeries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdventureWorksDwbuildVersion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AdventureWorksDWBuildVersion");

                entity.Property(e => e.Dbversion)
                    .HasColumnName("DBVersion")
                    .HasMaxLength(50);

                entity.Property(e => e.VersionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DatabaseLog>(entity =>
            {
                entity.HasKey(e => e.DatabaseLogId)
                    .HasName("PK_DatabaseLog_DatabaseLogID")
                    .IsClustered(false);

                entity.Property(e => e.DatabaseLogId).HasColumnName("DatabaseLogID");

                entity.Property(e => e.DatabaseUser)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Event)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Object).HasMaxLength(128);

                entity.Property(e => e.PostTime).HasColumnType("datetime");

                entity.Property(e => e.Schema).HasMaxLength(128);

                entity.Property(e => e.Tsql)
                    .IsRequired()
                    .HasColumnName("TSQL");

                entity.Property(e => e.XmlEvent)
                    .IsRequired()
                    .HasColumnType("xml");
            });

            modelBuilder.Entity<DimAccount>(entity =>
            {
                entity.HasKey(e => e.AccountKey);

                entity.Property(e => e.AccountDescription).HasMaxLength(50);

                entity.Property(e => e.AccountType).HasMaxLength(50);

                entity.Property(e => e.CustomMemberOptions).HasMaxLength(200);

                entity.Property(e => e.CustomMembers).HasMaxLength(300);

                entity.Property(e => e.Operator).HasMaxLength(50);

                entity.Property(e => e.ValueType).HasMaxLength(50);

                entity.HasOne(d => d.ParentAccountKeyNavigation)
                    .WithMany(p => p.InverseParentAccountKeyNavigation)
                    .HasForeignKey(d => d.ParentAccountKey)
                    .HasConstraintName("FK_DimAccount_DimAccount");
            });

            modelBuilder.Entity<DimCurrency>(entity =>
            {
                entity.HasKey(e => e.CurrencyKey)
                    .HasName("PK_DimCurrency_CurrencyKey");

                entity.HasIndex(e => e.CurrencyAlternateKey)
                    .HasName("AK_DimCurrency_CurrencyAlternateKey")
                    .IsUnique();

                entity.Property(e => e.CurrencyAlternateKey)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DimCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerKey)
                    .HasName("PK_DimCustomer_CustomerKey");

                entity.HasIndex(e => e.CustomerAlternateKey)
                    .IsUnique();

                entity.Property(e => e.AddressLine1).HasMaxLength(120);

                entity.Property(e => e.AddressLine2).HasMaxLength(120);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CommuteDistance).HasMaxLength(15);

                entity.Property(e => e.CustomerAlternateKey)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.DateFirstPurchase).HasColumnType("date");

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.EnglishEducation).HasMaxLength(40);

                entity.Property(e => e.EnglishOccupation).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FrenchEducation).HasMaxLength(40);

                entity.Property(e => e.FrenchOccupation).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(1);

                entity.Property(e => e.HouseOwnerFlag)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.SpanishEducation).HasMaxLength(40);

                entity.Property(e => e.SpanishOccupation).HasMaxLength(100);

                entity.Property(e => e.Suffix).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(8);

                entity.Property(e => e.YearlyIncome).HasColumnType("money");

                entity.HasOne(d => d.GeographyKeyNavigation)
                    .WithMany(p => p.DimCustomer)
                    .HasForeignKey(d => d.GeographyKey)
                    .HasConstraintName("FK_DimCustomer_DimGeography");
            });

            modelBuilder.Entity<DimDate>(entity =>
            {
                entity.HasKey(e => e.DateKey)
                    .HasName("PK_DimDate_DateKey");

                entity.HasIndex(e => e.FullDateAlternateKey)
                    .HasName("AK_DimDate_FullDateAlternateKey")
                    .IsUnique();

                entity.Property(e => e.DateKey).ValueGeneratedNever();

                entity.Property(e => e.EnglishDayNameOfWeek)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.EnglishMonthName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FrenchDayNameOfWeek)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FrenchMonthName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FullDateAlternateKey).HasColumnType("date");

                entity.Property(e => e.SpanishDayNameOfWeek)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SpanishMonthName)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<DimDepartmentGroup>(entity =>
            {
                entity.HasKey(e => e.DepartmentGroupKey);

                entity.Property(e => e.DepartmentGroupName).HasMaxLength(50);

                entity.HasOne(d => d.ParentDepartmentGroupKeyNavigation)
                    .WithMany(p => p.InverseParentDepartmentGroupKeyNavigation)
                    .HasForeignKey(d => d.ParentDepartmentGroupKey)
                    .HasConstraintName("FK_DimDepartmentGroup_DimDepartmentGroup");
            });

            modelBuilder.Entity<DimEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeKey)
                    .HasName("PK_DimEmployee_EmployeeKey");

                entity.Property(e => e.BaseRate).HasColumnType("money");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.EmergencyContactName).HasMaxLength(50);

                entity.Property(e => e.EmergencyContactPhone).HasMaxLength(25);

                entity.Property(e => e.EmployeeNationalIdalternateKey)
                    .HasColumnName("EmployeeNationalIDAlternateKey")
                    .HasMaxLength(15);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LoginId)
                    .HasColumnName("LoginID")
                    .HasMaxLength(256);

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.ParentEmployeeNationalIdalternateKey)
                    .HasColumnName("ParentEmployeeNationalIDAlternateKey")
                    .HasMaxLength(15);

                entity.Property(e => e.Phone).HasMaxLength(25);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.ParentEmployeeKeyNavigation)
                    .WithMany(p => p.InverseParentEmployeeKeyNavigation)
                    .HasForeignKey(d => d.ParentEmployeeKey)
                    .HasConstraintName("FK_DimEmployee_DimEmployee");

                entity.HasOne(d => d.SalesTerritoryKeyNavigation)
                    .WithMany(p => p.DimEmployee)
                    .HasForeignKey(d => d.SalesTerritoryKey)
                    .HasConstraintName("FK_DimEmployee_DimSalesTerritory");
            });

            modelBuilder.Entity<DimGeography>(entity =>
            {
                entity.HasKey(e => e.GeographyKey)
                    .HasName("PK_DimGeography_GeographyKey");

                entity.Property(e => e.City).HasMaxLength(30);

                entity.Property(e => e.CountryRegionCode).HasMaxLength(3);

                entity.Property(e => e.EnglishCountryRegionName).HasMaxLength(50);

                entity.Property(e => e.FrenchCountryRegionName).HasMaxLength(50);

                entity.Property(e => e.IpAddressLocator).HasMaxLength(15);

                entity.Property(e => e.PostalCode).HasMaxLength(15);

                entity.Property(e => e.SpanishCountryRegionName).HasMaxLength(50);

                entity.Property(e => e.StateProvinceCode).HasMaxLength(3);

                entity.Property(e => e.StateProvinceName).HasMaxLength(50);

                entity.HasOne(d => d.SalesTerritoryKeyNavigation)
                    .WithMany(p => p.DimGeography)
                    .HasForeignKey(d => d.SalesTerritoryKey)
                    .HasConstraintName("FK_DimGeography_DimSalesTerritory");
            });

            modelBuilder.Entity<DimOrganization>(entity =>
            {
                entity.HasKey(e => e.OrganizationKey);

                entity.Property(e => e.OrganizationName).HasMaxLength(50);

                entity.Property(e => e.PercentageOfOwnership).HasMaxLength(16);

                entity.HasOne(d => d.CurrencyKeyNavigation)
                    .WithMany(p => p.DimOrganization)
                    .HasForeignKey(d => d.CurrencyKey)
                    .HasConstraintName("FK_DimOrganization_DimCurrency");

                entity.HasOne(d => d.ParentOrganizationKeyNavigation)
                    .WithMany(p => p.InverseParentOrganizationKeyNavigation)
                    .HasForeignKey(d => d.ParentOrganizationKey)
                    .HasConstraintName("FK_DimOrganization_DimOrganization");
            });

            modelBuilder.Entity<DimProduct>(entity =>
            {
                entity.HasKey(e => e.ProductKey)
                    .HasName("PK_DimProduct_ProductKey");

                entity.HasIndex(e => new { e.ProductAlternateKey, e.StartDate })
                    .HasName("AK_DimProduct_ProductAlternateKey_StartDate")
                    .IsUnique();

                entity.Property(e => e.ArabicDescription).HasMaxLength(400);

                entity.Property(e => e.ChineseDescription).HasMaxLength(400);

                entity.Property(e => e.Class)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.DealerPrice).HasColumnType("money");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EnglishDescription).HasMaxLength(400);

                entity.Property(e => e.EnglishProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FrenchDescription).HasMaxLength(400);

                entity.Property(e => e.FrenchProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GermanDescription).HasMaxLength(400);

                entity.Property(e => e.HebrewDescription).HasMaxLength(400);

                entity.Property(e => e.JapaneseDescription).HasMaxLength(400);

                entity.Property(e => e.ListPrice).HasColumnType("money");

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.ProductAlternateKey).HasMaxLength(25);

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.SizeRange).HasMaxLength(50);

                entity.Property(e => e.SizeUnitMeasureCode)
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.SpanishProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StandardCost).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(7);

                entity.Property(e => e.Style)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.ThaiDescription).HasMaxLength(400);

                entity.Property(e => e.TurkishDescription).HasMaxLength(400);

                entity.Property(e => e.WeightUnitMeasureCode)
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.HasOne(d => d.ProductSubcategoryKeyNavigation)
                    .WithMany(p => p.DimProduct)
                    .HasForeignKey(d => d.ProductSubcategoryKey)
                    .HasConstraintName("FK_DimProduct_DimProductSubcategory");
            });

            modelBuilder.Entity<DimProductCategory>(entity =>
            {
                entity.HasKey(e => e.ProductCategoryKey)
                    .HasName("PK_DimProductCategory_ProductCategoryKey");

                entity.HasIndex(e => e.ProductCategoryAlternateKey)
                    .HasName("AK_DimProductCategory_ProductCategoryAlternateKey")
                    .IsUnique();

                entity.Property(e => e.EnglishProductCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FrenchProductCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SpanishProductCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DimProductSubcategory>(entity =>
            {
                entity.HasKey(e => e.ProductSubcategoryKey)
                    .HasName("PK_DimProductSubcategory_ProductSubcategoryKey");

                entity.HasIndex(e => e.ProductSubcategoryAlternateKey)
                    .HasName("AK_DimProductSubcategory_ProductSubcategoryAlternateKey")
                    .IsUnique();

                entity.Property(e => e.EnglishProductSubcategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FrenchProductSubcategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SpanishProductSubcategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.ProductCategoryKeyNavigation)
                    .WithMany(p => p.DimProductSubcategory)
                    .HasForeignKey(d => d.ProductCategoryKey)
                    .HasConstraintName("FK_DimProductSubcategory_DimProductCategory");
            });

            modelBuilder.Entity<DimPromotion>(entity =>
            {
                entity.HasKey(e => e.PromotionKey)
                    .HasName("PK_DimPromotion_PromotionKey");

                entity.HasIndex(e => e.PromotionAlternateKey)
                    .HasName("AK_DimPromotion_PromotionAlternateKey")
                    .IsUnique();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EnglishPromotionCategory).HasMaxLength(50);

                entity.Property(e => e.EnglishPromotionName).HasMaxLength(255);

                entity.Property(e => e.EnglishPromotionType).HasMaxLength(50);

                entity.Property(e => e.FrenchPromotionCategory).HasMaxLength(50);

                entity.Property(e => e.FrenchPromotionName).HasMaxLength(255);

                entity.Property(e => e.FrenchPromotionType).HasMaxLength(50);

                entity.Property(e => e.SpanishPromotionCategory).HasMaxLength(50);

                entity.Property(e => e.SpanishPromotionName).HasMaxLength(255);

                entity.Property(e => e.SpanishPromotionType).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DimReseller>(entity =>
            {
                entity.HasKey(e => e.ResellerKey)
                    .HasName("PK_DimReseller_ResellerKey");

                entity.HasIndex(e => e.ResellerAlternateKey)
                    .HasName("AK_DimReseller_ResellerAlternateKey")
                    .IsUnique();

                entity.Property(e => e.AddressLine1).HasMaxLength(60);

                entity.Property(e => e.AddressLine2).HasMaxLength(60);

                entity.Property(e => e.AnnualRevenue).HasColumnType("money");

                entity.Property(e => e.AnnualSales).HasColumnType("money");

                entity.Property(e => e.BankName).HasMaxLength(50);

                entity.Property(e => e.BusinessType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MinPaymentAmount).HasColumnType("money");

                entity.Property(e => e.OrderFrequency)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Phone).HasMaxLength(25);

                entity.Property(e => e.ProductLine).HasMaxLength(50);

                entity.Property(e => e.ResellerAlternateKey).HasMaxLength(15);

                entity.Property(e => e.ResellerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.GeographyKeyNavigation)
                    .WithMany(p => p.DimReseller)
                    .HasForeignKey(d => d.GeographyKey)
                    .HasConstraintName("FK_DimReseller_DimGeography");
            });

            modelBuilder.Entity<DimSalesReason>(entity =>
            {
                entity.HasKey(e => e.SalesReasonKey)
                    .HasName("PK_DimSalesReason_SalesReasonKey");

                entity.Property(e => e.SalesReasonName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SalesReasonReasonType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DimSalesTerritory>(entity =>
            {
                entity.HasKey(e => e.SalesTerritoryKey)
                    .HasName("PK_DimSalesTerritory_SalesTerritoryKey");

                entity.HasIndex(e => e.SalesTerritoryAlternateKey)
                    .HasName("AK_DimSalesTerritory_SalesTerritoryAlternateKey")
                    .IsUnique();

                entity.Property(e => e.SalesTerritoryCountry)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SalesTerritoryGroup).HasMaxLength(50);

                entity.Property(e => e.SalesTerritoryRegion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DimScenario>(entity =>
            {
                entity.HasKey(e => e.ScenarioKey);

                entity.Property(e => e.ScenarioName).HasMaxLength(50);
            });

            modelBuilder.Entity<FactAdditionalInternationalProductDescription>(entity =>
            {
                entity.HasKey(e => new { e.ProductKey, e.CultureName })
                    .HasName("PK_FactAdditionalInternationalProductDescription_ProductKey_CultureName");

                entity.Property(e => e.CultureName).HasMaxLength(50);

                entity.Property(e => e.ProductDescription).IsRequired();
            });

            modelBuilder.Entity<FactCallCenter>(entity =>
            {
                entity.HasIndex(e => new { e.DateKey, e.Shift })
                    .HasName("AK_FactCallCenter_DateKey_Shift")
                    .IsUnique();

                entity.Property(e => e.FactCallCenterId).HasColumnName("FactCallCenterID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Shift)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.WageType)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.DateKeyNavigation)
                    .WithMany(p => p.FactCallCenter)
                    .HasForeignKey(d => d.DateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactCallCenter_DimDate");
            });

            modelBuilder.Entity<FactCurrencyRate>(entity =>
            {
                entity.HasKey(e => new { e.CurrencyKey, e.DateKey })
                    .HasName("PK_FactCurrencyRate_CurrencyKey_DateKey");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.CurrencyKeyNavigation)
                    .WithMany(p => p.FactCurrencyRate)
                    .HasForeignKey(d => d.CurrencyKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactCurrencyRate_DimCurrency");

                entity.HasOne(d => d.DateKeyNavigation)
                    .WithMany(p => p.FactCurrencyRate)
                    .HasForeignKey(d => d.DateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactCurrencyRate_DimDate");
            });

            modelBuilder.Entity<FactFinance>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FinanceKey).ValueGeneratedOnAdd();

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactFinance_DimAccount");

                entity.HasOne(d => d.DateKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.DateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactFinance_DimDate");

                entity.HasOne(d => d.DepartmentGroupKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.DepartmentGroupKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactFinance_DimDepartmentGroup");

                entity.HasOne(d => d.OrganizationKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.OrganizationKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactFinance_DimOrganization");

                entity.HasOne(d => d.ScenarioKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ScenarioKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactFinance_DimScenario");
            });

            modelBuilder.Entity<FactInternetSales>(entity =>
            {
                entity.HasKey(e => new { e.SalesOrderNumber, e.SalesOrderLineNumber })
                    .HasName("PK_FactInternetSales_SalesOrderNumber_SalesOrderLineNumber");

                entity.Property(e => e.SalesOrderNumber).HasMaxLength(20);

                entity.Property(e => e.CarrierTrackingNumber).HasMaxLength(25);

                entity.Property(e => e.CustomerPonumber)
                    .HasColumnName("CustomerPONumber")
                    .HasMaxLength(25);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.ExtendedAmount).HasColumnType("money");

                entity.Property(e => e.Freight).HasColumnType("money");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.ProductStandardCost).HasColumnType("money");

                entity.Property(e => e.SalesAmount).HasColumnType("money");

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.TaxAmt).HasColumnType("money");

                entity.Property(e => e.TotalProductCost).HasColumnType("money");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.CurrencyKeyNavigation)
                    .WithMany(p => p.FactInternetSales)
                    .HasForeignKey(d => d.CurrencyKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactInternetSales_DimCurrency");

                entity.HasOne(d => d.CustomerKeyNavigation)
                    .WithMany(p => p.FactInternetSales)
                    .HasForeignKey(d => d.CustomerKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactInternetSales_DimCustomer");

                entity.HasOne(d => d.DueDateKeyNavigation)
                    .WithMany(p => p.FactInternetSalesDueDateKeyNavigation)
                    .HasForeignKey(d => d.DueDateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactInternetSales_DimDate1");

                entity.HasOne(d => d.OrderDateKeyNavigation)
                    .WithMany(p => p.FactInternetSalesOrderDateKeyNavigation)
                    .HasForeignKey(d => d.OrderDateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactInternetSales_DimDate");

                entity.HasOne(d => d.ProductKeyNavigation)
                    .WithMany(p => p.FactInternetSales)
                    .HasForeignKey(d => d.ProductKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactInternetSales_DimProduct");

                entity.HasOne(d => d.PromotionKeyNavigation)
                    .WithMany(p => p.FactInternetSales)
                    .HasForeignKey(d => d.PromotionKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactInternetSales_DimPromotion");

                entity.HasOne(d => d.SalesTerritoryKeyNavigation)
                    .WithMany(p => p.FactInternetSales)
                    .HasForeignKey(d => d.SalesTerritoryKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactInternetSales_DimSalesTerritory");

                entity.HasOne(d => d.ShipDateKeyNavigation)
                    .WithMany(p => p.FactInternetSalesShipDateKeyNavigation)
                    .HasForeignKey(d => d.ShipDateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactInternetSales_DimDate2");
            });

            modelBuilder.Entity<FactInternetSalesReason>(entity =>
            {
                entity.HasKey(e => new { e.SalesOrderNumber, e.SalesOrderLineNumber, e.SalesReasonKey })
                    .HasName("PK_FactInternetSalesReason_SalesOrderNumber_SalesOrderLineNumber_SalesReasonKey");

                entity.Property(e => e.SalesOrderNumber).HasMaxLength(20);

                entity.HasOne(d => d.SalesReasonKeyNavigation)
                    .WithMany(p => p.FactInternetSalesReason)
                    .HasForeignKey(d => d.SalesReasonKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactInternetSalesReason_DimSalesReason");

                entity.HasOne(d => d.SalesOrder)
                    .WithMany(p => p.FactInternetSalesReason)
                    .HasForeignKey(d => new { d.SalesOrderNumber, d.SalesOrderLineNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactInternetSalesReason_FactInternetSales");
            });

            modelBuilder.Entity<FactProductInventory>(entity =>
            {
                entity.HasKey(e => new { e.ProductKey, e.DateKey });

                entity.Property(e => e.MovementDate).HasColumnType("date");

                entity.Property(e => e.UnitCost).HasColumnType("money");

                entity.HasOne(d => d.DateKeyNavigation)
                    .WithMany(p => p.FactProductInventory)
                    .HasForeignKey(d => d.DateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactProductInventory_DimDate");

                entity.HasOne(d => d.ProductKeyNavigation)
                    .WithMany(p => p.FactProductInventory)
                    .HasForeignKey(d => d.ProductKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactProductInventory_DimProduct");
            });

            modelBuilder.Entity<FactResellerSales>(entity =>
            {
                entity.HasKey(e => new { e.SalesOrderNumber, e.SalesOrderLineNumber })
                    .HasName("PK_FactResellerSales_SalesOrderNumber_SalesOrderLineNumber");

                entity.Property(e => e.SalesOrderNumber).HasMaxLength(20);

                entity.Property(e => e.CarrierTrackingNumber).HasMaxLength(25);

                entity.Property(e => e.CustomerPonumber)
                    .HasColumnName("CustomerPONumber")
                    .HasMaxLength(25);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.ExtendedAmount).HasColumnType("money");

                entity.Property(e => e.Freight).HasColumnType("money");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.ProductStandardCost).HasColumnType("money");

                entity.Property(e => e.SalesAmount).HasColumnType("money");

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.TaxAmt).HasColumnType("money");

                entity.Property(e => e.TotalProductCost).HasColumnType("money");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.CurrencyKeyNavigation)
                    .WithMany(p => p.FactResellerSales)
                    .HasForeignKey(d => d.CurrencyKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactResellerSales_DimCurrency");

                entity.HasOne(d => d.DueDateKeyNavigation)
                    .WithMany(p => p.FactResellerSalesDueDateKeyNavigation)
                    .HasForeignKey(d => d.DueDateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactResellerSales_DimDate1");

                entity.HasOne(d => d.EmployeeKeyNavigation)
                    .WithMany(p => p.FactResellerSales)
                    .HasForeignKey(d => d.EmployeeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactResellerSales_DimEmployee");

                entity.HasOne(d => d.OrderDateKeyNavigation)
                    .WithMany(p => p.FactResellerSalesOrderDateKeyNavigation)
                    .HasForeignKey(d => d.OrderDateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactResellerSales_DimDate");

                entity.HasOne(d => d.ProductKeyNavigation)
                    .WithMany(p => p.FactResellerSales)
                    .HasForeignKey(d => d.ProductKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactResellerSales_DimProduct");

                entity.HasOne(d => d.PromotionKeyNavigation)
                    .WithMany(p => p.FactResellerSales)
                    .HasForeignKey(d => d.PromotionKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactResellerSales_DimPromotion");

                entity.HasOne(d => d.ResellerKeyNavigation)
                    .WithMany(p => p.FactResellerSales)
                    .HasForeignKey(d => d.ResellerKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactResellerSales_DimReseller");

                entity.HasOne(d => d.SalesTerritoryKeyNavigation)
                    .WithMany(p => p.FactResellerSales)
                    .HasForeignKey(d => d.SalesTerritoryKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactResellerSales_DimSalesTerritory");

                entity.HasOne(d => d.ShipDateKeyNavigation)
                    .WithMany(p => p.FactResellerSalesShipDateKeyNavigation)
                    .HasForeignKey(d => d.ShipDateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactResellerSales_DimDate2");
            });

            modelBuilder.Entity<FactSalesQuota>(entity =>
            {
                entity.HasKey(e => e.SalesQuotaKey)
                    .HasName("PK_FactSalesQuota_SalesQuotaKey");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.SalesAmountQuota).HasColumnType("money");

                entity.HasOne(d => d.DateKeyNavigation)
                    .WithMany(p => p.FactSalesQuota)
                    .HasForeignKey(d => d.DateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactSalesQuota_DimDate");

                entity.HasOne(d => d.EmployeeKeyNavigation)
                    .WithMany(p => p.FactSalesQuota)
                    .HasForeignKey(d => d.EmployeeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactSalesQuota_DimEmployee");
            });

            modelBuilder.Entity<FactSurveyResponse>(entity =>
            {
                entity.HasKey(e => e.SurveyResponseKey)
                    .HasName("PK_FactSurveyResponse_SurveyResponseKey");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EnglishProductCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EnglishProductSubcategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CustomerKeyNavigation)
                    .WithMany(p => p.FactSurveyResponse)
                    .HasForeignKey(d => d.CustomerKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactSurveyResponse_CustomerKey");

                entity.HasOne(d => d.DateKeyNavigation)
                    .WithMany(p => p.FactSurveyResponse)
                    .HasForeignKey(d => d.DateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FactSurveyResponse_DateKey");
            });

            modelBuilder.Entity<NewFactCurrencyRate>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CurrencyDate).HasColumnType("date");

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("CurrencyID")
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<ProspectiveBuyer>(entity =>
            {
                entity.HasKey(e => e.ProspectiveBuyerKey)
                    .HasName("PK_ProspectiveBuyer_ProspectiveBuyerKey");

                entity.Property(e => e.AddressLine1).HasMaxLength(120);

                entity.Property(e => e.AddressLine2).HasMaxLength(120);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City).HasMaxLength(30);

                entity.Property(e => e.Education).HasMaxLength(40);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(1);

                entity.Property(e => e.HouseOwnerFlag)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Occupation).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.PostalCode).HasMaxLength(15);

                entity.Property(e => e.ProspectAlternateKey).HasMaxLength(15);

                entity.Property(e => e.Salutation).HasMaxLength(8);

                entity.Property(e => e.StateProvinceCode).HasMaxLength(3);

                entity.Property(e => e.YearlyIncome).HasColumnType("money");
            });

            modelBuilder.Entity<VAssocSeqLineItems>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vAssocSeqLineItems");

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<VAssocSeqOrders>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vAssocSeqOrders");

                entity.Property(e => e.IncomeGroup)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Region).HasMaxLength(50);
            });

            modelBuilder.Entity<VDmprep>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vDMPrep");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.EnglishProductCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IncomeGroup)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Region).HasMaxLength(50);
            });

            modelBuilder.Entity<VTargetMail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vTargetMail");

                entity.Property(e => e.AddressLine1).HasMaxLength(120);

                entity.Property(e => e.AddressLine2).HasMaxLength(120);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CommuteDistance).HasMaxLength(15);

                entity.Property(e => e.CustomerAlternateKey)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.DateFirstPurchase).HasColumnType("date");

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.EnglishEducation).HasMaxLength(40);

                entity.Property(e => e.EnglishOccupation).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.FrenchEducation).HasMaxLength(40);

                entity.Property(e => e.FrenchOccupation).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(1);

                entity.Property(e => e.HouseOwnerFlag)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Region).HasMaxLength(50);

                entity.Property(e => e.SpanishEducation).HasMaxLength(40);

                entity.Property(e => e.SpanishOccupation).HasMaxLength(100);

                entity.Property(e => e.Suffix).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(8);

                entity.Property(e => e.YearlyIncome).HasColumnType("money");
            });

            modelBuilder.Entity<VTimeSeries>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vTimeSeries");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.ModelRegion).HasMaxLength(56);

                entity.Property(e => e.ReportingDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
