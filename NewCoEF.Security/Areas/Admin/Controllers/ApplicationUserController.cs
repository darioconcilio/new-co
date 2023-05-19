using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewCoEF.Security.Areas.Admin.Models;
using NewCoEF.Security.Data;
using NewCoEF.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Security.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminPolicy")]
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ApplicationUserController(UserManager<ApplicationUser> usermanager, ApplicationDbContext context)
        {
            _userManager = usermanager;
            _context = context;
        }

        private string decodeRole(IEnumerable<IdentityRole> rj)
        {
            return rj.Equals(null) ? string.Empty : string.Join(", ", rj.SelectMany(o => o.Name).ToArray());
        }

        public IActionResult Index()
        {
            //Recupero tutti i binomi utente-ruolo
            var result = (from u in _context.Users

                              //LEFT OUTER JOIN
                          join ur in _context.UserRoles on u.Id equals ur.UserId into urj
                          from subUr in urj.DefaultIfEmpty()

                              //LEFT OUTER JOIN
                          join r in _context.Roles on subUr.RoleId equals r.Id into rj
                          from subR in rj.DefaultIfEmpty()

                          select new
                          {
                              User = u,
                              Roles = subR
                          }).ToList();

            //Preparo il ViewModel per la View
            var usersWithRolesInfo = new List<UserViewModel>();

            foreach (var item in result)
            {
                if (usersWithRolesInfo.Exists(uwr => uwr.Username == item.User.UserName))
                {
                    var userToUpdate = usersWithRolesInfo
                        .Single(uwr => uwr.Username == item.User.UserName);

                    userToUpdate.Roles += userToUpdate.Roles == string.Empty ? item.Roles.Name : $",{item.Roles.Name}";
                }
                else
                {
                    usersWithRolesInfo.Add(new UserViewModel(item.User)
                    {
                        Roles = item.Roles.Name
                    });
                }
            }

            return View(usersWithRolesInfo);
        }


    }
}
