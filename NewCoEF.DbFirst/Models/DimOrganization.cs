using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class DimOrganization
    {
        public DimOrganization()
        {
            InverseParentOrganizationKeyNavigation = new HashSet<DimOrganization>();
        }

        public int OrganizationKey { get; set; }
        public int? ParentOrganizationKey { get; set; }
        public string PercentageOfOwnership { get; set; }
        public string OrganizationName { get; set; }
        public int? CurrencyKey { get; set; }

        public virtual DimCurrency CurrencyKeyNavigation { get; set; }
        public virtual DimOrganization ParentOrganizationKeyNavigation { get; set; }
        public virtual ICollection<DimOrganization> InverseParentOrganizationKeyNavigation { get; set; }
    }
}
