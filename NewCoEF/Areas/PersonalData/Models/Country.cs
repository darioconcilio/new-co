using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Areas.PersonalData.Models
{
    public class Country
    {
        public Country()
        {

        }

        public Guid ID { get; set; }

        [Display(Name = "Paese")]
        public string Name { get; set; }

    }
}
