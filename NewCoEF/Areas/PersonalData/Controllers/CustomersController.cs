using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCoEF.Shared.Areas.PersonalData.Models;
using NewCoEF.Areas.PersonalData.ViewModels;
using NewCoEF.Areas.PersonalData.Base;
using Microsoft.AspNetCore.DataProtection;
using System.Security.Cryptography;

namespace NewCoEF.Areas.PersonalData.Controllers
{
    [Area("PersonalData")]
    public class CustomersController : BaseController
    {
        private readonly NewCoEFDbContext _context;

        public CustomersController(NewCoEFDbContext context)
        {
            _context = context;
        }

        // GET: PersonalData/Customers
        public async Task<IActionResult> Index([FromServices] IDataProtectionProvider provider)
        {
            //return View(await _context.Customers.ToListAsync());

            var customers = await (from rec in _context.Customers
                                                      .Include("CountryRef")
                                                      .Include("CountyRef")
                                   select rec).ToListAsync();

            foreach (var cust in customers)
            {
                try
                {
                    #region protect data
                    IDataProtector protector = provider.CreateProtector("dataToProtected");
                    cust.Name = protector.Unprotect(cust.Name);
                    #endregion
                }
                catch (CryptographicException ex)
                {
                    //Console.WriteLine(ex.Message);
                }
            }

            return View(customers);
        }

        // GET: PersonalData/Customers/Details/5
        public async Task<IActionResult> Details(Guid? id,
            [FromServices] IDataProtectionProvider provider)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(o => o.CountryRef)
                .Include(o => o.CountyRef)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            try
            {
                #region protect data
                IDataProtector protector = provider.CreateProtector("dataToProtected");
                customer.Name = protector.Unprotect(customer.Name);
                #endregion
            }
            catch (CryptographicException ex)
            {
                //Console.WriteLine(ex.Message);
            }

            return View(customer);
        }

        // GET: PersonalData/Customers/Create
        public async Task<IActionResult> Create()
        {
            var item = new Customer();
            CustomerViewModel vm = new CustomerViewModel(item);

            vm.Countries = await _context.Countries.ToListAsync();
            vm.Counties = await _context.Counties.ToListAsync();

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

        // POST: PersonalData/Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Code,Address,PostCode,City,VATRegistrationCode,CountryId,CountyId")] Customer customer,
            [FromServices] IDataProtectionProvider provider)
        {
            if (ModelState.IsValid)
            {
                customer.ID = Guid.NewGuid();

                #region protect data
                IDataProtector protector = provider.CreateProtector("dataToProtected");
                customer.Name = protector.Protect(customer.Name);
                #endregion

                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: PersonalData/Customers/Edit/5
        public async Task<IActionResult> Edit(Guid? id,
            [FromServices] IDataProtectionProvider provider)
        {
            Customer item = await (from rec in _context.Customers
                                   .Include(o => o.CountryRef)
                                   .Include(o => o.CountyRef)
                                   where rec.ID == id
                                   select rec).SingleOrDefaultAsync();

            if (item == null)
                return NotFound();

            try
            {
                #region protect data
                IDataProtector protector = provider.CreateProtector("dataToProtected");
                item.Name = protector.Unprotect(item.Name);
                #endregion
            }
            catch (CryptographicException ex)
            {
                //Console.WriteLine(ex.Message);
            }

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
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,Code,Address,PostCode,City,VATRegistrationCode,CountryId,CountyId")] Customer customer,
            [FromServices] IDataProtectionProvider provider)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    #region protect data
                    IDataProtector protector = provider.CreateProtector("dataToProtected");
                    customer.Name = protector.Protect(customer.Name);
                    #endregion

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
        public async Task<IActionResult> Delete(Guid? id,
            [FromServices] IDataProtectionProvider provider)
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

            try
            {
                #region protect data
                IDataProtector protector = provider.CreateProtector("dataToProtected");
                customer.Name = protector.Unprotect(customer.Name);
                #endregion
            }
            catch (CryptographicException ex)
            {
                //Console.WriteLine(ex.Message);
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
