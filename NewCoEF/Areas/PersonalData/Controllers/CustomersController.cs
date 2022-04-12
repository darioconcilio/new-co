using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewCoEF;
using NewCoEF.Areas.PersonalData.Models;
using NewCoEF.Areas.PersonalData.ViewModels;

namespace NewCoEF.Areas.PersonalData.Controllers
{
    [Area("PersonalData")]
    public class CustomersController : Controller
    {
        private readonly NewCoEFDbContext _context;

        public CustomersController(NewCoEFDbContext context)
        {
            _context = context;
        }

        // GET: PersonalData/Customers
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Customers.ToListAsync());

            var customers = await (from rec in _context.Customers
                                                      .Include("CountryRef")
                                                      .Include("CountyRef")
                                   select rec).ToListAsync();
            return View(customers);
        }

        // GET: PersonalData/Customers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: PersonalData/Customers/Create
        public IActionResult Create()
        {
            var item = new Customer();
            CustomerViewModel vm = new CustomerViewModel(item);

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            return View(vm);
        }

        // POST: PersonalData/Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Code,Address,PostCode,City,VATRegistrationCode")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.ID = Guid.NewGuid();
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: PersonalData/Customers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            Customer item = await (from rec in _context.Customers.Include("CountyRef").Include("CountryRef")
                                   where rec.ID == id
                                   select rec).SingleOrDefaultAsync();

            if (item == null)
                return NotFound();

            CustomerViewModel vm = new CustomerViewModel(item)
            {
                //Caricamento delle dropdown
                Countries = await _context.Countries.ToListAsync(),
                Counties = await _context.Counties.ToListAsync()
            };

            vm.Counties.Insert(0, new County()
            {
                ID = new Guid(9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9),
                Name = "Seleziona una provincia"
            });

            vm.Countries.Insert(0, new Country()
            {
                ID = new Guid(9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9),
                Name = "Seleziona un paese"
            });

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            return View(vm);
        }

        // POST: PersonalData/Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,Code,Address,PostCode,City,VATRegistrationCode,CountryRefId,CountyRefId")] Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.ID))
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
            return View(customer);
        }

        // GET: PersonalData/Customers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: PersonalData/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(Guid id)
        {
            return _context.Customers.Any(e => e.ID == id);
        }
    }
}
