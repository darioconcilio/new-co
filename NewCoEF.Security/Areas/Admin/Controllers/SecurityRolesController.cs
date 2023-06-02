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
    public class SecurityRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SecurityRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SecurityRole
        public async Task<IActionResult> Index()
        {
            return View(await _context.SecurityRoles.ToListAsync());
        }

        // GET: Admin/SecurityRole/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var SecurityRole = await _context.SecurityRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (SecurityRole == null)
            {
                return NotFound();
            }

            return View(SecurityRole);
        }

        // GET: Admin/SecurityRole/Create
        public IActionResult Create()
        {
            return View(new SecurityRole());
        }

        // POST: Admin/SecurityRole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NormalizedName,ConcurrencyStamp,Description")] SecurityRole SecurityRole)
        {
            if (ModelState.IsValid)
            {

                SecurityRole.NormalizedName = SecurityRole.Name.Normalize().ToUpper();

                _context.Add(SecurityRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(SecurityRole);
        }

        // GET: Admin/SecurityRole/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var SecurityRole = await _context.SecurityRoles.FindAsync(id);
            if (SecurityRole == null)
            {
                return NotFound();
            }
            return View(SecurityRole);
        }

        // POST: Admin/SecurityRole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,NormalizedName,ConcurrencyStamp,Description")] SecurityRole SecurityRole)
        {
            if (id != SecurityRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    SecurityRole.NormalizedName = SecurityRole.Name.Normalize().ToUpper();

                    var roleToUpdate = await (from rec in _context.SecurityRoles
                                              where rec.Id == id
                                              select rec).SingleAsync();

                    roleToUpdate.Name = SecurityRole.Name;
                    roleToUpdate.Description = SecurityRole.Description;
                    roleToUpdate.NormalizedName = SecurityRole.NormalizedName;

                    _context.Update(roleToUpdate);
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!SecurityRoleExists(SecurityRole.Id))
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
            return View(SecurityRole);
        }

        // GET: Admin/SecurityRole/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var SecurityRole = await _context.SecurityRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (SecurityRole == null)
            {
                return NotFound();
            }

            return View(SecurityRole);
        }

        // POST: Admin/SecurityRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var SecurityRole = await _context.SecurityRoles.FindAsync(id);
            _context.SecurityRoles.Remove(SecurityRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SecurityRoleExists(string id)
        {
            return _context.SecurityRoles.Any(e => e.Id == id);
        }
    }
}
