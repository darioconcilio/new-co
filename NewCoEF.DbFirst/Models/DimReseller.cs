using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class DimReseller
    {
        public DimReseller()
        {
            FactResellerSales = new HashSet<FactResellerSales>();
        }

        public int ResellerKey { get; set; }
        public int? GeographyKey { get; set; }
        public string ResellerAlternateKey { get; set; }
        public string Phone { get; set; }
        public string BusinessType { get; set; }
        public string ResellerName { get; set; }
        public int? NumberEmployees { get; set; }
        public string OrderFrequency { get; set; }
        public byte? OrderMonth { get; set; }
        public int? FirstOrderYear { get; set; }
        public int? LastOrderYear { get; set; }
        public string ProductLine { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public decimal? AnnualSales { get; set; }
        public string BankName { get; set; }
        public byte? MinPaymentType { get; set; }
        public decimal? MinPaymentAmount { get; set; }
        public decimal? AnnualRevenue { get; set; }
        public int? YearOpened { get; set; }

        public virtual DimGeography GeographyKeyNavigation { get; set; }
        public virtual ICollection<FactResellerSales> FactResellerSales { get; set; }
    }
}
