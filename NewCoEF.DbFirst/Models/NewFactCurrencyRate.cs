using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class NewFactCurrencyRate
    {
        public float? AverageRate { get; set; }
        public string CurrencyId { get; set; }
        public DateTime? CurrencyDate { get; set; }
        public float? EndOfDayRate { get; set; }
        public int? CurrencyKey { get; set; }
        public int? DateKey { get; set; }
    }
}
