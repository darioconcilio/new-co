using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCoEF.Areas.PersonalData.Base;
using NewCoEF.Shared.Areas.PersonalData.Models;

namespace NewCoEF.Areas.PersonalData.Controllers
{
    [Area("PersonalData")]
    public class ItemsController : ControllerCustom
    {
        private readonly NewCoEFDbContext _context;

        public ItemsController(NewCoEFDbContext context)
        {
            _context = context;
        }

        // GET: PersonalData/Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }

        // GET: PersonalData/Items/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Wizard style
            var item = await _context.Items.FirstOrDefaultAsync(m => m.Id == id);

            #region Linq style
            //var item = await (from rec in _context.Items
            //                      where rec.Id == id
            //                      select rec).SingleOrDefaultAsync();
            #endregion

            if (item == null)
            {
                //Custom Error View https://www.prowaretech.com/Computer/AspNetCore/HandleViewNotFoundErrors
                return NotFound();
            }

            return View(item);
        }

        // GET: PersonalData/Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalData/Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,UnitPrice,Inventory,No")] Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    item.Id = Guid.NewGuid();

                    _context.Add(item);

                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder(ex.Message);

                if (ex.InnerException != null)
                    sb.AppendLine(ex.InnerException.Message);

                //Generic error model
                ModelState.AddModelError("", sb.ToString());
            }

            return View(item);
        }

        // GET: PersonalData/Items/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }



        // POST: PersonalData/Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //https://docs.microsoft.com/it-it/aspnet/core/security/anti-request-forgery?view=aspnetcore-3.1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Description,UnitPrice,Inventory,No")] Item item)
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,UnitPrice,Inventory,No")] Item item)
        //public async Task<IActionResult> Edit(Item item)
        {
            /*if (id != item.Id)
            {
                return NotFound();
            }*/

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
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
            return View(item);
        }

        // GET: PersonalData/Items/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: PersonalData/Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(Guid id)
        {
            return _context.Items.Any(e => e.Id == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorMessage = ErrorMessage
            });
        }
    }
}
