using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewCoEF;
using NewCoEF.Areas.PersonalData.Models;

namespace NewCoEF.Areas.PersonalData.Controllers
{
    [Area("PersonalData")]
    public class CountiesController : Controller
    {
        private readonly NewCoEFDbContext _context;

        public CountiesController(NewCoEFDbContext context)
        {
            _context = context;
        }

        // GET: PersonalData/Counties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Counties.ToListAsync());
        }

        // GET: PersonalData/Counties/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var county = await _context.Counties
                .FirstOrDefaultAsync(m => m.ID == id);
            if (county == null)
            {
                return NotFound();
            }

            return View(county);
        }

        // GET: PersonalData/Counties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalData/Counties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Code")] County county)
        {
            if (ModelState.IsValid)
            {
                county.ID = Guid.NewGuid();
                _context.Add(county);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(county);
        }

        // GET: PersonalData/Counties/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var county = await _context.Counties.FindAsync(id);
            if (county == null)
            {
                return NotFound();
            }
            return View(county);
        }

        // POST: PersonalData/Counties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,Code")] County county)
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

        // GET: PersonalData/Counties/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var county = await _context.Counties
                .FirstOrDefaultAsync(m => m.ID == id);
            if (county == null)
            {
                return NotFound();
            }

            return View(county);
        }

        // POST: PersonalData/Counties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var county = await _context.Counties.FindAsync(id);
            _context.Counties.Remove(county);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountyExists(Guid id)
        {
            return _context.Counties.Any(e => e.ID == id);
        }
    }
}
