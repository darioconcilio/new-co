using NewCoEF.Security.Areas.Admin.Models;
using NewCoEF.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Security.Areas.Admin.Extensions
{
    public static class UserViewModelExtension
    {
        public static UserViewModel ToUserViewModel(this ApplicationUser user)
        {
            return new UserViewModel(user);
        }
    }
}
