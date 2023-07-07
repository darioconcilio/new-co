using NewCo.Shared;
using NewCo.Shared.Resources.Customer;
using NewCoEF.Shared.Areas.Sales.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Customer_Name", ResourceType = typeof(CustomerResource))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorsResource))]
        [MaxLength(50, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(ErrorsResource))]
        public string Name { get; set; }

        [Display(Name = "Customer_Code", ResourceType = typeof(CustomerResource))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorsResource))]
        [MaxLength(20, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(ErrorsResource))]
        public string Code { get; set; }

        [Display(Name = "Customer_Address", ResourceType = typeof(CustomerResource))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorsResource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(ErrorsResource))]
        public string Address { get; set; }

        [Display(Name = "Customer_PostCode", ResourceType = typeof(CustomerResource))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorsResource))]
        [MaxLength(5, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(ErrorsResource))]
        public string PostCode { get; set; }

        [Display(Name = "Customer_City", ResourceType = typeof(CustomerResource))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorsResource))]
        [MaxLength(100, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(ErrorsResource))]
        public string City { get; set; }

        [Display(Name = "Customer_VATRegistrationCode", ResourceType = typeof(CustomerResource))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorsResource))]
        [MaxLength(20, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(ErrorsResource))]
        public string VATRegistrationCode { get; set; }

        [Display(Name = "Customer_CountyId", ResourceType = typeof(CustomerResource))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorsResource))]
        public Guid? CountyId { get; set; }

        [Display(Name = "Customer_CountryId", ResourceType = typeof(CustomerResource))]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorsResource))]
        public Guid? CountryId { get; set; }

        #region aggiornamento
        /*[Display(Name = "Codice Destinatario")]
        [MaxLength(7)]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorsResource))]
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
