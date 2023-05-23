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
            Id = user.Id;
            Username = user.UserName;
            Email = user.Email;
            Roles = string.Empty;
            ExistRoles = new List<SelectedRole>();
        }

        [Key]
        public string Id { get; internal set; }
        public string Username { get; internal set; }
        public string Email { get; internal set; }
        public string Roles { get; internal set; }

        public List<SelectedRole> ExistRoles { get; set; }
    }
}
