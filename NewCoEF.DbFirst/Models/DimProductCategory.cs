using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class DimProductCategory
    {
        public DimProductCategory()
        {
            DimProductSubcategory = new HashSet<DimProductSubcategory>();
        }

        public int ProductCategoryKey { get; set; }
        public int? ProductCategoryAlternateKey { get; set; }
        public string EnglishProductCategoryName { get; set; }
        public string SpanishProductCategoryName { get; set; }
        public string FrenchProductCategoryName { get; set; }

        public virtual ICollection<DimProductSubcategory> DimProductSubcategory { get; set; }
    }
}
