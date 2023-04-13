﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Security.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Full name")]
        [MaxLength(50)]
        public string Fullname { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]

        public DateTime BirthdayDate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        [MaxLength(100)]
        public string Address { get; set; }
    }
}
