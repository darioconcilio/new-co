using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class FactProductInventory
    {
        public int ProductKey { get; set; }
        public int DateKey { get; set; }
        public DateTime MovementDate { get; set; }
        public decimal UnitCost { get; set; }
        public int UnitsIn { get; set; }
        public int UnitsOut { get; set; }
        public int UnitsBalance { get; set; }

        public virtual DimDate DateKeyNavigation { get; set; }
        public virtual DimProduct ProductKeyNavigation { get; set; }
    }
}
