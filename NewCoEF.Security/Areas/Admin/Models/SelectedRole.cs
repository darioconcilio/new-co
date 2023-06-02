using Microsoft.AspNetCore.Identity;
using NewCoEF.Security.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Security.Areas.Admin.Models
{
    public class SelectedRole
    {
        public SelectedRole(SecurityRole role)
        {
            Id = role.Id;
            RoleName = role.Name;
            Selected = false;
            Role = role;
        }

        [Display(Name = "Id")]
        [Key]
        public string Id { get; set; }

        [Display(Name = "Nome")]
        public string RoleName { get; set; }

        [Display(Name = "Selezionato")]
        public bool Selected { get; set; }

        [Display(Name = "Roulo")]
        public SecurityRole Role { get; set; }
    }
}
