using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class DimSalesReason
    {
        public DimSalesReason()
        {
            FactInternetSalesReason = new HashSet<FactInternetSalesReason>();
        }

        public int SalesReasonKey { get; set; }
        public int SalesReasonAlternateKey { get; set; }
        public string SalesReasonName { get; set; }
        public string SalesReasonReasonType { get; set; }

        public virtual ICollection<FactInternetSalesReason> FactInternetSalesReason { get; set; }
    }
}
