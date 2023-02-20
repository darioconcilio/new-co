using NewCoEF.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {

        }

        [Display(Name = "Title", ResourceType = typeof(SharedResource))]
        public string Title { get; set; }
    }
}
