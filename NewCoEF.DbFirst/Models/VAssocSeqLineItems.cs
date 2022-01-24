using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class VAssocSeqLineItems
    {
        public string OrderNumber { get; set; }
        public byte LineNumber { get; set; }
        public string Model { get; set; }
    }
}
