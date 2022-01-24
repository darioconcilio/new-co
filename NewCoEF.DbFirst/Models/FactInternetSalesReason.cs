using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class FactInternetSalesReason
    {
        public string SalesOrderNumber { get; set; }
        public byte SalesOrderLineNumber { get; set; }
        public int SalesReasonKey { get; set; }

        public virtual FactInternetSales SalesOrder { get; set; }
        public virtual DimSalesReason SalesReasonKeyNavigation { get; set; }
    }
}
