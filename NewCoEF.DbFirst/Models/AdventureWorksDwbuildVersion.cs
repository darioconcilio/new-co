using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class AdventureWorksDwbuildVersion
    {
        public string Dbversion { get; set; }
        public DateTime? VersionDate { get; set; }
    }
}
