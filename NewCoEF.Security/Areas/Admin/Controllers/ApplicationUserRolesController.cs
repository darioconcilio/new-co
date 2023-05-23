using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewCoEF.Security.Data;
using NewCoEF.Security.Models;

namespace NewCoEF.Security.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminPolicy")]
    public class ApplicationUserRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ApplicationUserRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationUserRoles.ToListAsync());
        }

        // GET: Admin/ApplicationUserRoles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUserRoles = await _context.ApplicationUserRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUserRoles == null)
            {
                return NotFound();
            }

            return View(applicationUserRoles);
        }

        // GET: Admin/ApplicationUserRoles/Create
        public IActionResult Create()
        {
            return View(new ApplicationUserRoles());
        }

        // POST: Admin/ApplicationUserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NormalizedName,ConcurrencyStamp,Description")] ApplicationUserRoles applicationUserRoles)
        {
            if (ModelState.IsValid)
            {

                applicationUserRoles.NormalizedName = applicationUserRoles.Name.Normalize().ToUpper();

                _context.Add(applicationUserRoles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUserRoles);
        }

        // GET: Admin/ApplicationUserRoles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUserRoles = await _context.ApplicationUserRoles.FindAsync(id);
            if (applicationUserRoles == null)
            {
                return NotFound();
            }
            return View(applicationUserRoles);
        }

        // POST: Admin/ApplicationUserRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,NormalizedName,ConcurrencyStamp,Description")] ApplicationUserRoles applicationUserRoles)
        {
            if (id != applicationUserRoles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    applicationUserRoles.NormalizedName = applicationUserRoles.Name.Normalize().ToUpper();

                    var roleToUpdate = await (from rec in _context.ApplicationUserRoles
                                              where rec.Id == id
                                              select rec).SingleAsync();

                    roleToUpdate.Name = applicationUserRoles.Name;
                    roleToUpdate.Description = applicationUserRoles.Description;
                    roleToUpdate.NormalizedName = applicationUserRoles.NormalizedName;

                    _context.Update(roleToUpdate);
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!ApplicationUserRolesExists(applicationUserRoles.Id))
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
            return View(applicationUserRoles);
        }

        // GET: Admin/ApplicationUserRoles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUserRoles = await _context.ApplicationUserRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUserRoles == null)
            {
                return NotFound();
            }

            return View(applicationUserRoles);
        }

        // POST: Admin/ApplicationUserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationUserRoles = await _context.ApplicationUserRoles.FindAsync(id);
            _context.ApplicationUserRoles.Remove(applicationUserRoles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserRolesExists(string id)
        {
            return _context.ApplicationUserRoles.Any(e => e.Id == id);
        }
    }
}
