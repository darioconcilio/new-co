using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Areas.PersonalData.Models
{
    public class Customer
    {
        public Customer()
        {
            
        }

        public Customer(SqlDataReader dr)
        {
            ID = Convert.ToInt32(dr["ID"]);
            Name = dr["Name"].ToString();
            Code = dr["Code"].ToString();
            Address = dr["Address"].ToString();
            PostCode = dr["Post Code"].ToString();
            City = dr["City"].ToString();
            CountryId = Convert.ToInt32(dr["Country ID"]);
            CountyId = Convert.ToInt32(dr["County ID"]);
            VATRegistrationCode = dr["VAT Registration Code"].ToString();
        }

        public int ID { get; set; }

        [Display(Name = "Ragione Sociale")]
        public string Name { get; set; }

        [Display(Name = "Codice")]
        public string Code { get; set; }

        [Display(Name = "Indirizzo")]
        public string Address { get; set; }

        [Display(Name = "CAP")]
        public string PostCode { get; set; }

        [Display(Name = "Città")]
        public string City { get; set; }

        [Display(Name = "Provincia")]
        public int CountyId { get; set; }

        [Display(Name = "Paese")]
        public int CountryId { get; set; }

        [Display(Name = "P. IVA")]
        public string VATRegistrationCode { get; set; }

        public County CountyRef { get; set; }

        public Country CountryRef { get; set; }

    }
}
