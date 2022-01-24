using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class VDmprep
    {
        public string EnglishProductCategoryName { get; set; }
        public string Model { get; set; }
        public int CustomerKey { get; set; }
        public string Region { get; set; }
        public int? Age { get; set; }
        public string IncomeGroup { get; set; }
        public short CalendarYear { get; set; }
        public short FiscalYear { get; set; }
        public byte Month { get; set; }
        public string OrderNumber { get; set; }
        public byte LineNumber { get; set; }
        public short Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
