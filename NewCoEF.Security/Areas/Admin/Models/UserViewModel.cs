using Microsoft.AspNetCore.Identity;
using NewCoEF.Security.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewCoEF.Security.Areas.Admin.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {

        }

        public UserViewModel(ApplicationUser user)
        {
            Username = user.UserName;
            Email = user.Email;
            Roles = string.Empty;
        }

        [Key]
        public string Username { get; internal set; }
        public string Email { get; internal set; }
        public string Roles { get; internal set; }
    }
}
