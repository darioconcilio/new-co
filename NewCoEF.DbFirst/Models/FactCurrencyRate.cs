using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class FactCurrencyRate
    {
        public int CurrencyKey { get; set; }
        public int DateKey { get; set; }
        public double AverageRate { get; set; }
        public double EndOfDayRate { get; set; }
        public DateTime? Date { get; set; }

        public virtual DimCurrency CurrencyKeyNavigation { get; set; }
        public virtual DimDate DateKeyNavigation { get; set; }
    }
}
