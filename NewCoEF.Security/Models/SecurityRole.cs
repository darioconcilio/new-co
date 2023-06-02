using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Security.Models
{
    public class SecurityRole : IdentityRole
    {
        public SecurityRole()
        {
            Id = Guid.NewGuid().ToString();
            ConcurrencyStamp = Guid.NewGuid().ToString();
        }

        public string Description { get; set; }
    }
}
