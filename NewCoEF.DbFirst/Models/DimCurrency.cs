using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class DimCurrency
    {
        public DimCurrency()
        {
            DimOrganization = new HashSet<DimOrganization>();
            FactCurrencyRate = new HashSet<FactCurrencyRate>();
            FactInternetSales = new HashSet<FactInternetSales>();
            FactResellerSales = new HashSet<FactResellerSales>();
        }

        public int CurrencyKey { get; set; }
        public string CurrencyAlternateKey { get; set; }
        public string CurrencyName { get; set; }

        public virtual ICollection<DimOrganization> DimOrganization { get; set; }
        public virtual ICollection<FactCurrencyRate> FactCurrencyRate { get; set; }
        public virtual ICollection<FactInternetSales> FactInternetSales { get; set; }
        public virtual ICollection<FactResellerSales> FactResellerSales { get; set; }
    }
}
