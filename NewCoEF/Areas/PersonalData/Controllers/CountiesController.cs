using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCoEF.Shared.Areas.PersonalData.Models;
using NewCoEF.Areas.PersonalData.ViewModels;
using NewCoEF.Areas.PersonalData.Base;

namespace NewCoEF.Areas.PersonalData.Controllers
{
    [Area("PersonalData")]
    public class CountiesController : BaseController
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
        public async Task<IActionResult> Create(County county)
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

        public IActionResult RemoveDisconnectedMode()
        {
            return View(new CountyViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> RemoveDisconnectedMode(CountyViewModel vm)
        {
            //Creazione dell'item da eliminare al di fuori del contesto
            var countyToDelete = new County()
            {
                ID = vm.ID
            };

            //Esiste la collezione sotto Change Tracker?
            var itemsToDelete = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted);

            //Esiste l'item che voglio eliminare?
            var myCounty = _context.ChangeTracker.Entries()
                .SingleOrDefault(e => (e.Entity as County).ID == vm.ID);

            _context.Attach(countyToDelete);

            //Esiste la collezione sotto Change Tracker?
            itemsToDelete = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted);

            //Esiste l'item che voglio eliminare?
            myCounty = _context.ChangeTracker.Entries()
                .SingleOrDefault(e => (e.Entity as County).ID == vm.ID);

            _context.Remove(countyToDelete);

            //Esiste la collezione sotto Change Tracker?
            itemsToDelete = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted);

            //Esiste l'item che voglio eliminare?
            myCounty = _context.ChangeTracker.Entries()
                .SingleOrDefault(e => (e.Entity as County).ID == vm.ID);

            await _context.SaveChangesAsync();

            //e dopo?

            //Esiste la collezione sotto Change Tracker?
            itemsToDelete = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted);

            //Esiste l'item che voglio eliminare?
            myCounty = _context.ChangeTracker.Entries()
                .SingleOrDefault(e => (e.Entity as County).ID == vm.ID);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateDisconnectedMode()
        {
            return View(new CountyViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDisconnectedMode(CountyViewModel vm)
        {
            //Creazione dell'item da eliminare al di fuori del contesto
            var countyToUpdate = new County()
            {
                ID = vm.ID,
                Code = vm.Code,
                Name = vm.Name
            };

            //Esiste la collezione sotto Change Tracker?
            var itemsToUpdate = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified);

            //Esiste l'item che si vuole aggiornare?
            var myCounty = _context.ChangeTracker.Entries()
                .SingleOrDefault(e => (e.Entity as County).ID == vm.ID);

            _context.Attach(countyToUpdate);

            //Esiste la collezione sotto Change Tracker?
            itemsToUpdate = _context.ChangeTracker.Entries()
               .Where(e => e.State == EntityState.Modified);

            //Esiste l'item che si vuole aggiornare?
            myCounty = _context.ChangeTracker.Entries()
               .SingleOrDefault(e => (e.Entity as County).ID == vm.ID);

            _context.Update(countyToUpdate);

            //Esiste la collezione sotto Change Tracker?
            itemsToUpdate = _context.ChangeTracker.Entries()
               .Where(e => e.State == EntityState.Modified);

            //Esiste l'item che si vuole aggiornare?
            myCounty = _context.ChangeTracker.Entries()
               .SingleOrDefault(e => (e.Entity as County).ID == vm.ID);

            await _context.SaveChangesAsync();

            //e dopo?

            //Esiste la collezione sotto Change Tracker?
            itemsToUpdate = _context.ChangeTracker.Entries()
               .Where(e => e.State == EntityState.Modified);

            //Esiste l'item che si vuole aggiornare?
            myCounty = _context.ChangeTracker.Entries()
               .SingleOrDefault(e => (e.Entity as County).ID == vm.ID);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AdvancedSearch()
        {
            var vm = new IndexByExtendedQueryViewModel();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AdvancedSearch(IndexByExtendedQueryViewModel vm)
        {
            var itemsFound = await _context.Counties
                .FromSqlRaw("SELECT * FROM [dbo].[Provincie]({0})", vm.Filter)
                .OrderBy(c => c.Name)
                .ToListAsync();

            /*var itemsFound = _context.Counties
                .FromSqlRaw("[GetProvincie] {0}", vm.Filter).AsEnumerable();*/

            vm.CountiesFound = itemsFound.ToList();

            return View(vm);
        }
    }
}
