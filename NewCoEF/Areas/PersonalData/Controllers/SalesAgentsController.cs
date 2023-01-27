using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCoEF.Areas.PersonalData.Base;
using NewCoEF.Areas.PersonalData.Models;

namespace NewCoEF.Areas.PersonalData.Controllers
{
    [Area("PersonalData")]
    public class SalesAgentsController : ControllerCustom
    {
        private readonly NewCoEFDbContext _context;

        public SalesAgentsController(NewCoEFDbContext context)
        {
            _context = context;
        }

        // GET: PersonalData/SalesAgents
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesAgents.ToListAsync());
        }

        // GET: PersonalData/SalesAgents/Details/5
        public async Task<IActionResult> Details(Guid? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var SalesAgent = await _context.SalesAgents
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (SalesAgent == null)
            {
                return NotFound();
            }

            return View(SalesAgent);
        }

        // GET: PersonalData/SalesAgents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalData/SalesAgents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalesAgent salesAgent)
        {
            if (ModelState.IsValid)
            {
                salesAgent.Id = Guid.NewGuid();
                _context.Add(salesAgent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesAgent);
        }

        // GET: PersonalData/SalesAgents/Edit/5
        public async Task<IActionResult> Edit(Guid? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var SalesAgent = await _context.SalesAgents.FindAsync(Id);
            if (SalesAgent == null)
            {
                return NotFound();
            }
            return View(SalesAgent);
        }

        // POST: PersonalData/SalesAgents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid Id, SalesAgent SalesAgent)
        {
            if (Id != SalesAgent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(SalesAgent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesAgentExists(SalesAgent.Id))
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
            return View(SalesAgent);
        }

        // GET: PersonalData/SalesAgents/Delete/5
        public async Task<IActionResult> Delete(Guid? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var SalesAgent = await _context.SalesAgents
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (SalesAgent == null)
            {
                return NotFound();
            }

            return View(SalesAgent);
        }

        // POST: PersonalData/SalesAgents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid Id)
        {
            var SalesAgent = await _context.SalesAgents.FindAsync(Id);
            _context.SalesAgents.Remove(SalesAgent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesAgentExists(Guid Id)
        {
            return _context.SalesAgents.Any(e => e.Id == Id);
        }

       

        
    }
}
