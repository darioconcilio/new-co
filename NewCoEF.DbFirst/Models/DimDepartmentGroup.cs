using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class DimDepartmentGroup
    {
        public DimDepartmentGroup()
        {
            InverseParentDepartmentGroupKeyNavigation = new HashSet<DimDepartmentGroup>();
        }

        public int DepartmentGroupKey { get; set; }
        public int? ParentDepartmentGroupKey { get; set; }
        public string DepartmentGroupName { get; set; }

        public virtual DimDepartmentGroup ParentDepartmentGroupKeyNavigation { get; set; }
        public virtual ICollection<DimDepartmentGroup> InverseParentDepartmentGroupKeyNavigation { get; set; }
    }
}
