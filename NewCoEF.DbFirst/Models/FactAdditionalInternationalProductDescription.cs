using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class FactAdditionalInternationalProductDescription
    {
        public int ProductKey { get; set; }
        public string CultureName { get; set; }
        public string ProductDescription { get; set; }
    }
}
