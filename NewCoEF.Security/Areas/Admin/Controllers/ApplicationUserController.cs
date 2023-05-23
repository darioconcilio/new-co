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

        #region Edit

        // GET: Admin/ApplicationUser/Edit/506f1c8d-7aeb-424b-a026-e5d36ffb3993
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userToEdit = await _context.Users.FindAsync(id);
            if (userToEdit == null)
            {
                return NotFound();
            }

            //Contesto necessario alla view Edit
            var output = new UserViewModel(userToEdit);

            //Carico i ruoli esistenti
            var allRoles = from rec in _context.ApplicationUserRoles
                           select rec;

            foreach (var role in allRoles)
                output.ExistRoles.Add(new SelectedRole(role));

            //Recupero i ruoli dell'utente richiesto
            var rolesOfCurrentUser = from rec in _context.UserRoles
                                     where rec.UserId == id
                                     select rec;

            foreach(var userRole in rolesOfCurrentUser)
            {
                var selectedUserRole = output.ExistRoles.Single(r => r.Id == userRole.RoleId);
                selectedUserRole.Selected = true;
            }

            return View(output);
        }

        /*
        // POST: Admin/ApplicationUser/Edit/506f1c8d-7aeb-424b-a026-e5d36ffb3993
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, County county)
        {
            if (id != county.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(county);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountyExists(county.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(county);
        }
        */
        #endregion
    }
}
