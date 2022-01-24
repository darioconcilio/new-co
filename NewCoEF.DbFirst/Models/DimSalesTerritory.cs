using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class DimSalesTerritory
    {
        public DimSalesTerritory()
        {
            DimEmployee = new HashSet<DimEmployee>();
            DimGeography = new HashSet<DimGeography>();
            FactInternetSales = new HashSet<FactInternetSales>();
            FactResellerSales = new HashSet<FactResellerSales>();
        }

        public int SalesTerritoryKey { get; set; }
        public int? SalesTerritoryAlternateKey { get; set; }
        public string SalesTerritoryRegion { get; set; }
        public string SalesTerritoryCountry { get; set; }
        public string SalesTerritoryGroup { get; set; }
        public byte[] SalesTerritoryImage { get; set; }

        public virtual ICollection<DimEmployee> DimEmployee { get; set; }
        public virtual ICollection<DimGeography> DimGeography { get; set; }
        public virtual ICollection<FactInternetSales> FactInternetSales { get; set; }
        public virtual ICollection<FactResellerSales> FactResellerSales { get; set; }
    }
}
