using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class VTimeSeries
    {
        public string ModelRegion { get; set; }
        public int? TimeIndex { get; set; }
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public short CalendarYear { get; set; }
        public byte Month { get; set; }
        public DateTime? ReportingDate { get; set; }
    }
}
