using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class FactCallCenter
    {
        public int FactCallCenterId { get; set; }
        public int DateKey { get; set; }
        public string WageType { get; set; }
        public string Shift { get; set; }
        public short LevelOneOperators { get; set; }
        public short LevelTwoOperators { get; set; }
        public short TotalOperators { get; set; }
        public int Calls { get; set; }
        public int AutomaticResponses { get; set; }
        public int Orders { get; set; }
        public short IssuesRaised { get; set; }
        public short AverageTimePerIssue { get; set; }
        public double ServiceGrade { get; set; }
        public DateTime? Date { get; set; }

        public virtual DimDate DateKeyNavigation { get; set; }
    }
}
