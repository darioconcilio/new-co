using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class FactSalesQuota
    {
        public int SalesQuotaKey { get; set; }
        public int EmployeeKey { get; set; }
        public int DateKey { get; set; }
        public short CalendarYear { get; set; }
        public byte CalendarQuarter { get; set; }
        public decimal SalesAmountQuota { get; set; }
        public DateTime? Date { get; set; }

        public virtual DimDate DateKeyNavigation { get; set; }
        public virtual DimEmployee EmployeeKeyNavigation { get; set; }
    }
}
