using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NewCoEF.DbFirst.Models
{
    public partial class ProspectiveBuyer
    {
        public int ProspectiveBuyerKey { get; set; }
        public string ProspectAlternateKey { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public decimal? YearlyIncome { get; set; }
        public byte? TotalChildren { get; set; }
        public byte? NumberChildrenAtHome { get; set; }
        public string Education { get; set; }
        public string Occupation { get; set; }
        public string HouseOwnerFlag { get; set; }
        public byte? NumberCarsOwned { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvinceCode { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Salutation { get; set; }
        public int? Unknown { get; set; }
    }
}
