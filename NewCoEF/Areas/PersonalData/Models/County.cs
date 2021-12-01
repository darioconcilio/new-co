﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Areas.PersonalData.Models
{
    public class County
    {
        public County()
        {

        }

        //Le caratteristiche sono state definite nel model builder
        public Guid ID { get; set; }

        [Display(Name = "Provincia")]
        public string Name { get; set; }

        [Display(Name = "Codice")]
        public string Code { get; set; }
    }
}