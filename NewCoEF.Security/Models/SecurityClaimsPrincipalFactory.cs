using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NewCoEF.Security.Models
{
    public class SecurityClaimsPrincipalFactory
        : UserClaimsPrincipalFactory<SecurityUser, IdentityRole>
    {
        public SecurityClaimsPrincipalFactory(
            UserManager<SecurityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        { }

        public async override Task<ClaimsPrincipal> CreateAsync(SecurityUser user)
        {
            var principal = await base.CreateAsync(user);
            var identity = (ClaimsIdentity)principal.Identity;

            var claims = new List<Claim>();
            if (user.IsAdmin)
            {
                claims.Add(new Claim(JwtClaimTypes.Role, "admin"));
            }
            else
            {
                claims.Add(new Claim(JwtClaimTypes.Role, "user"));
            }

            claims.Add(new Claim("LanguageCode", user.LanguageCode));

            identity.AddClaims(claims);
            return principal;
        }
    }
}
