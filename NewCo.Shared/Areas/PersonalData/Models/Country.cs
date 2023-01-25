using NewCo.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewCoEF.Shared.Areas.PersonalData.Models
{
    public class Country
    {
        public Country()
        {

        }

        [Key]
        public Guid ID { get; set; }

        //Lunghezza massima e minima: si possono utilizzare il placeholder in questo modo
        //{0} Nome della proprietà
        //{1} Lunghezza massima
        //{2} Lunghezza minima
        [MaxLength(50, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(ErrorsResource))] //Property
        [StringLength(50)] //Data Field
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorsResource))]
        [Display(Name = "Country_Name", ResourceType = typeof(ErrorsResource))]
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

    }
}
