using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Areas.PersonalData.Models
{
    public class SalesAgent
    {
        public SalesAgent()
        {

        }

        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Agent_Name")]
        [MaxLength(50, ErrorMessageResourceName = "MaxLengthErrorMessage")]
        [StringLength(80)]
        [Required(ErrorMessageResourceName = "Required")]
        public string Name { get; set; }

        [Display(Name = "Agent_Mail")]
        [MaxLength(80, ErrorMessageResourceName = "MaxLengthErrorMessage")]
        [StringLength(80)]
        public string Mail { get; set; }

    }
}
