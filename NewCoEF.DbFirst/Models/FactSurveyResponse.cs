using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class FactSurveyResponse
    {
        public int SurveyResponseKey { get; set; }
        public int DateKey { get; set; }
        public int CustomerKey { get; set; }
        public int ProductCategoryKey { get; set; }
        public string EnglishProductCategoryName { get; set; }
        public int ProductSubcategoryKey { get; set; }
        public string EnglishProductSubcategoryName { get; set; }
        public DateTime? Date { get; set; }

        public virtual DimCustomer CustomerKeyNavigation { get; set; }
        public virtual DimDate DateKeyNavigation { get; set; }
    }
}
