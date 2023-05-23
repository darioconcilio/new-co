using Microsoft.AspNetCore.Identity;
using NewCoEF.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Security.Areas.Admin.Models
{
    public class SelectedRole
    {
        public SelectedRole(ApplicationUserRoles role)
        {
            Id = role.Id;
            RoleName = role.Name;
            Selected = false;
            Role = role;
        }

        public string Id { get; set; }
        public string RoleName { get; set; }
        public bool Selected { get; set; }

        public ApplicationUserRoles Role { get; set; }
    }
}
