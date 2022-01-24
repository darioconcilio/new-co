using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class VTargetMail
    {
        public int CustomerKey { get; set; }
        public int? GeographyKey { get; set; }
        public string CustomerAlternateKey { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool? NameStyle { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Suffix { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public decimal? YearlyIncome { get; set; }
        public byte? TotalChildren { get; set; }
        public byte? NumberChildrenAtHome { get; set; }
        public string EnglishEducation { get; set; }
        public string SpanishEducation { get; set; }
        public string FrenchEducation { get; set; }
        public string EnglishOccupation { get; set; }
        public string SpanishOccupation { get; set; }
        public string FrenchOccupation { get; set; }
        public string HouseOwnerFlag { get; set; }
        public byte? NumberCarsOwned { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Phone { get; set; }
        public DateTime? DateFirstPurchase { get; set; }
        public string CommuteDistance { get; set; }
        public string Region { get; set; }
        public int? Age { get; set; }
        public int BikeBuyer { get; set; }
    }
}
