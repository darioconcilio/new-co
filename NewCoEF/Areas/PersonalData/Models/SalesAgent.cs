using NewCoEF.Resources;
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

        [Display(Name = "SalesAgent_Name", ResourceType = typeof(SharedResource))]
        [MaxLength(50, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(SharedResource))]
        [StringLength(50)]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(SharedResource))]
        public string Name { get; set; }

        [Display(Name="SalesAgent_Mail", ResourceType =typeof(SharedResource))]
        [MaxLength(80, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(SharedResource))]
        [StringLength(80)]
        public string Mail { get; set; }

    }
}
