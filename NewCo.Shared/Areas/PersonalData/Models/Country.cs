using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Shared.Areas.PersonalData.Models
{
    public class Country
    {
        public Country()
        {

        }

        [Key]
        public Guid ID { get; set; }

        [MaxLength(33)] //Property
        [StringLength(22)] //Data Field
        [Required]
        [Display(Name = "Paese")]
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

    }
}
