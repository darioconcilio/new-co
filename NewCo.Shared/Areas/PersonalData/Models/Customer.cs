using NewCo.Shared;
using NewCoEF.Shared.Areas.Sales.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Shared.Areas.PersonalData.Models
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public Guid ID { get; set; }

        [Display(Name = "Customer_Name", ResourceType = typeof(ErrorsResource))]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Customer_Code", ResourceType = typeof(ErrorsResource))]
        [Required]
        public string Code { get; set; }

        [Display(Name = "Customer_Address", ResourceType = typeof(ErrorsResource))]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Customer_PostCode", ResourceType = typeof(ErrorsResource))]
        [Required]
        public string PostCode { get; set; }

        [Display(Name = "Customer_City", ResourceType = typeof(ErrorsResource))]
        [Required]
        public string City { get; set; }

        [Display(Name = "Customer_VATRegistrationCode", ResourceType = typeof(ErrorsResource))]
        [Required]
        public string VATRegistrationCode { get; set; }

        [Display(Name = "Customer_CountyId", ResourceType = typeof(ErrorsResource))]
        [Required]
        public Guid? CountyId { get; set; }

        [Display(Name = "Customer_CountryId", ResourceType = typeof(ErrorsResource))]
        [Required]
        public Guid? CountryId { get; set; }

        #region aggiornamento
        /*[Display(Name = "Codice Destinatario")]
        [MaxLength(7)]
        [Required]
        public string SDICode { get; set; }*/
        #endregion

        #region Navigation Property

        //public County CountyRef { get; set; }
        public virtual County CountyRef { get; set; }

        //public Country CountryRef { get; set; }
        public virtual Country CountryRef { get; set; }

        //public ICollection<Order> Orders { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        #endregion
    }
}
