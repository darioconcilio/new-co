using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class SecurityUsersController : Controller
    {
        private readonly UserManager<SecurityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public SecurityUsersController(UserManager<SecurityUser> usermanager, ApplicationDbContext context)
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
                        Roles = item.Roles?.Name
                    });
                }
            }

            return View(usersWithRolesInfo);
        }

        #region Edit

        // GET: Admin/SecurityUser/Edit/506f1c8d-7aeb-424b-a026-e5d36ffb3993
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
            var allRoles = from rec in _context.SecurityRoles
                           select rec;

            output.ExistRoles = new List<SelectedRole>();
            foreach (var role in allRoles)
                output.ExistRoles.Add(new SelectedRole(role));

            //Recupero i ruoli dell'utente richiesto
            var rolesOfCurrentUser = from rec in _context.UserRoles
                                     where rec.UserId == id
                                     select rec;

            foreach (var userRole in rolesOfCurrentUser)
            {
                var selectedUserRole = output.ExistRoles.Single(r => r.Id == userRole.RoleId);
                selectedUserRole.Selected = true;
            }

            return View(output);
        }


        //// POST: Admin/SecurityUser/Edit/506f1c8d-7aeb-424b-a026-e5d36ffb3993
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("Id,Username,ExistRoles")] UserViewModel userViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            //Aggiornamento dell'utente
        //            var userToUpdate = await (from rec in _context.Users
        //                                      where rec.Id == id
        //                                      select rec).SingleOrDefaultAsync();
        //            if (userToUpdate != null)
        //            {
        //                //userToUpdate.UserName = model.Username;
        //                //_context.Users.Update(userToUpdate);

        //                //Cerco i ruoli esistenti (se ce ne sono)
        //                var userRolesToDelete = await (from rec in _context.UserRoles
        //                                               where rec.UserId == id
        //                                               select rec).ToListAsync();
        //                if (userRolesToDelete.Count > 0)
        //                {
        //                    //Elimino eventuali ruoli già associati
        //                    foreach (var userRoleToDelete in userRolesToDelete)
        //                        _context.UserRoles.Remove(userRoleToDelete);
        //                }

        //                //Assegno quelli nuovi
        //                foreach (var selectedRole in userViewModel.ExistRoles.Where(r => r.Selected == true))
        //                {
        //                    await _context.UserRoles.AddAsync(new IdentityUserRole<string>()
        //                    {
        //                        RoleId = selectedRole.Role.Id,
        //                        UserId = id
        //                    });
        //                }
        //                await _context.SaveChangesAsync();
        //            }

        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            throw;
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return RedirectToAction(nameof(Index));
        //}

        [Route("Admin/SecurityUser/RemoveLinkUserRole/{id}")]
        public async Task<IActionResult> RemoveLinkUserRole(string id, string roleid)
        {
            try
            {
                var userRoleToDelete = await (from rec in _context.UserRoles
                                              where rec.RoleId == roleid && rec.UserId == id
                                              select rec).SingleOrDefaultAsync();
                if (userRoleToDelete != null)
                {
                    _context.UserRoles.Remove(userRoleToDelete);
                    await _context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            try
            {
                var userFound = await (from rec in _context.Users
                                       where rec.Id == id
                                       select rec).SingleOrDefaultAsync();

                var userViewModel = new UserViewModel(userFound);
                return RedirectToAction("Edit", "SecurityUsers", new { id = userViewModel.Id });
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [Route("Admin/SecurityUser/AddLinkUserRole/{id}")]
        public async Task<IActionResult> AddLinkUserRole(string id, string roleid)
        {
            try
            {
                var userRoleToAdd = new SecurityUserRoles()
                {
                    RoleId = roleid,
                    UserId = id
                };

                _context.UserRoles.Add(userRoleToAdd);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            try
            {
                var userFound = await (from rec in _context.Users
                                       where rec.Id == id
                                       select rec).SingleOrDefaultAsync();

                var userViewModel = new UserViewModel(userFound);
                return RedirectToAction("Edit", "SecurityUsers", new { id = userViewModel.Id });
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        #endregion
    }
}
