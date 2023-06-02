using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public UserViewModel(SecurityUser user)
        {
            Id = user.Id;
            Username = user.UserName;
            Email = user.Email;
            //Roles = string.Empty;
            //ExistRoles = new List<SelectedRole>();
        }

        [Key]
        public string Id { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }
        public List<SelectedRole> ExistRoles { get; set; }
    }
}
