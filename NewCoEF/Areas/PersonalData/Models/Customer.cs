using NewCoEF.Areas.Sales.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Areas.PersonalData.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public Guid ID { get; set; }

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

        [Display(Name = "P. IVA")]
        public string VATRegistrationCode { get; set; }

        [Display(Name = "Provincia")]
        public Guid? CountyRefId { get; set; }

        [Display(Name = "Paese")]
        public Guid? CountryRefId { get; set; }

        #region aggiornamento
        /*[Display(Name = "Codice Destinatario")]
        [MaxLength(7)]
        [Required]
        public string SDICode { get; set; }*/
        #endregion

        #region Navigation Property

        public County CountyRef { get; set; }

        public Country CountryRef { get; set; }

        public ICollection<Order> Orders { get; set; }

        #endregion
    }
}
