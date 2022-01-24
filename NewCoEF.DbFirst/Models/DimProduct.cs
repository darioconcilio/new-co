using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class DimProduct
    {
        public DimProduct()
        {
            FactInternetSales = new HashSet<FactInternetSales>();
            FactProductInventory = new HashSet<FactProductInventory>();
            FactResellerSales = new HashSet<FactResellerSales>();
        }

        public int ProductKey { get; set; }
        public string ProductAlternateKey { get; set; }
        public int? ProductSubcategoryKey { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string EnglishProductName { get; set; }
        public string SpanishProductName { get; set; }
        public string FrenchProductName { get; set; }
        public decimal? StandardCost { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public short? SafetyStockLevel { get; set; }
        public short? ReorderPoint { get; set; }
        public decimal? ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeRange { get; set; }
        public double? Weight { get; set; }
        public int? DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public decimal? DealerPrice { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public string ModelName { get; set; }
        public byte[] LargePhoto { get; set; }
        public string EnglishDescription { get; set; }
        public string FrenchDescription { get; set; }
        public string ChineseDescription { get; set; }
        public string ArabicDescription { get; set; }
        public string HebrewDescription { get; set; }
        public string ThaiDescription { get; set; }
        public string GermanDescription { get; set; }
        public string JapaneseDescription { get; set; }
        public string TurkishDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }

        public virtual DimProductSubcategory ProductSubcategoryKeyNavigation { get; set; }
        public virtual ICollection<FactInternetSales> FactInternetSales { get; set; }
        public virtual ICollection<FactProductInventory> FactProductInventory { get; set; }
        public virtual ICollection<FactResellerSales> FactResellerSales { get; set; }
    }
}
