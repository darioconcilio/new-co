using NewCoEF.Areas.PersonalData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Areas.PersonalData.ViewModels
{
    public class CountyViewModel
    {
        public CountyViewModel()
        {

        }

        public CountyViewModel(Guid pId, string pName, string pCode)
        {
            ID = pId;
            Name = pName;
            Code = pCode;
        }

        public Guid ID { get; set; }

        [Display(Name = "Provincia")]
        public string Name { get; set; }

        [Display(Name = "Codice")]
        public string Code { get; set; }
    }

    
}
