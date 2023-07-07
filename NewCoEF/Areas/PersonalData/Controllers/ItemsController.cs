using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewCoEF.Areas.PersonalData.Base;
using NewCoEF.Shared.Areas.PersonalData.Models;

namespace NewCoEF.Areas.PersonalData.Controllers
{
    [Area("PersonalData")]
    public class ItemsController : BaseController
    {
        private readonly NewCoEFDbContext _context;
        private readonly ILogger<ItemsController> logger;

        public ItemsController(NewCoEFDbContext context, ILogger<ItemsController> logger)
        {
            _context = context;
            this.logger = logger;
        }

        /// <summary>
        /// Trace = 0, Debug = 1, Information = 2, Warning = 3, Error = 4, Critical = 5, and None = 6.
        /// </summary>
        /// <param name="ex"></param>
        private void dummyMethod(Exception ex)
        {
            logger.LogTrace("Dettaglio massimo con informazioni sensibili");
            logger.LogDebug(1001, "Informazioni utili alla diagnostica");
            logger.LogInformation("Informazioni descrittive e generiche");
            logger.LogWarning("Attenzione ad un evento particolare ma non bloccante");
            logger.LogError(5001, ex, "E' un errore bloccante!");
            logger.LogCritical(ex, "Errore bloccante e catastrofico, possibili perdite di dati!");
        }

        // GET: PersonalData/Items
        public async Task<IActionResult> Index()
        {
            logger.LogInformation("Request item list");

            dummyMethod(new Exception("Errore generico"));

            var itemsUnProtected = await _context.Items.ToListAsync();

            foreach(var item in itemsUnProtected)
                item.RemoveProtection();

            return View(itemsUnProtected);
        }

        // GET: PersonalData/Items/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            logger.LogInformation($"Request item details for {id}");

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
                logger.LogError(5001, $"Item {id} not found");

                return NotFound();
            }

            item.RemoveProtection();
            return View(item);
        }

        // GET: PersonalData/Items/Create
        public IActionResult Create()
        {
            logger.LogInformation("Request new item");
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

                    item.ApplyProtection();

                    _context.Add(item);

                    await _context.SaveChangesAsync();

                    //Assegnazione parametri posizionale
                    logger.LogInformation($"Posted add item {item.Id} {item.Description}");

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder(ex.Message);

                if (ex.InnerException != null)
                    sb.AppendLine(ex.InnerException.Message);

                logger.LogCritical($"Posting adding new item {item.Id} failed: {sb}");

                //Generic error model
                ModelState.AddModelError("", sb.ToString());
            }

            return View(item);
        }

        // GET: PersonalData/Items/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            logger.LogInformation($"Request edit item for {id}");

            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                logger.LogError($"Request edit item {item.Id} not found");
                return NotFound();
            }

            item.RemoveProtection();

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
                    item.ApplyProtection();

                    _context.Update(item);
                    await _context.SaveChangesAsync();
                    logger.LogInformation($"Posted edit item {item.Id} updated");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!ItemExists(item.Id))
                    {
                        logger.LogError($"Posting edit item {item.Id} not found");
                        return NotFound();
                    }
                    else
                    {
                        logger.LogError($"Posting edit item {item.Id}, error: {ex.Message}");
                        throw;
                    }
                }
                catch(Exception ex)
                {
                    logger.LogCritical($"Posting edit item {item.Id} failed, error: {ex.Message}");
                }

                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: PersonalData/Items/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            logger.LogInformation($"Request delete item for {id}");

            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                logger.LogError($"Requesting delete item {id} non found");
                return NotFound();
            }

            item.RemoveProtection();

            return View(item);
        }

        // POST: PersonalData/Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var item = await _context.Items.FindAsync(id);
            try
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();

                logger.LogInformation($"Posted deleting item {id}");
            }
            catch(Exception ex)
            {
                logger.LogCritical($"Requesting delete item {id} failed, error {ex.Message}");
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(Guid id)
        {
            return _context.Items.Any(e => e.Id == id);
        }

        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorMessage = ErrorMessage
            });
        }*/
    }
}
