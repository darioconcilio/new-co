using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCoEF.Areas.PersonalData.Models;
using NewCoEF.Areas.Sales.Models;
using NewCoEF.Areas.Sales.ViewModels;
using NewCoEF.Commons;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Areas.Sales.Controllers
{
    [Area("Sales")]
    public class OrdersController : Controller
    {
        private readonly NewCoEFDbContext _context;

        public OrdersController(NewCoEFDbContext context)
        {
            _context = context;
        }

        // GET: Sales/Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.Include("CustomerRef").Include("Lines").ToListAsync());
        }

        // GET: Sales/Orders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Sales/Orders/Create
        public async Task<IActionResult> CreateAsync()
        {
            var newOrder = new Order();

            //Assego il numero protocollo al nuovo ordine
            newOrder.Id = Guid.NewGuid();
            //Propongo la data di oggi
            newOrder.Date = DateTime.Today;

            newOrder.No = await GetLastOrderNoAsync();

            OrderViewModel vm = new OrderViewModel(newOrder)
            {
                //Caricamento delle dropdown
                Customers = await _context.Customers.ToListAsync()
            };

            vm.Customers.Insert(0, new Customer()
            {
                ID = Guid.Empty,
                Name = "Seleziona una cliente"
            });


            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            return View(vm);
        }

        // POST: Sales/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderViewModel vmToInsert)
        {
            var bundle = new Bundle
            {
                Result = true
            };

            try

            {
                await _context.AddAsync(vmToInsert);
                await _context.SaveChangesAsync();

                ViewBag.Error = false;
                ViewBag.ErrorMessage = "";

                return View(vmToInsert);
            }
            catch (Exception ex)
            {
                ViewBag.Error = true;
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Edit", "Orders", new { id = vmToInsert.Id });
            }

        }

        // GET: Sales/Orders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";
            OrderViewModel vm = new OrderViewModel();

            try
            {
                var orderToFind = await (from rec in _context.Orders.Include("Lines")
                                         where rec.Id == id
                                         select rec).SingleOrDefaultAsync();

                if (orderToFind != null)
                    vm = new OrderViewModel(orderToFind);
                else
                    return RedirectToAction(nameof(Index));

                vm.Customers = await _context.Customers.ToListAsync();
                vm.Customers.Insert(0, new Customer()
                {
                    ID = Guid.Empty,
                    Name = "Seleziona una cliente"
                });

                return View(vm);
            }
            catch (Exception ex)
            {
                ViewBag.Error = true;
                ViewBag.ErrorMessage = ex.Message;
                return View(vm);
            }

        }

        private bool OrderExists(Guid id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }

        public async Task<string> GetLastOrderNoAsync()
        {
            //Anno corrente a 2 cifre
            var year2 = DateTime.Now.Year.ToString().Substring(2, 2);
            //Lunghezza protocollo 7 fisso
            var lastOrderNo = $"O{year2}0001";

            //Recupero tutti gli ordini (avrei potuto fare una chiamata già filtrata per anno corrente, ma...
            var orders = await _context.Orders.ToListAsync();
            //Filtro gli ordini dell'anno corrente
            var ordersOfCurrentYear = orders.Where(o => o.No.Substring(1, 2) == year2).ToList();

            //Verifico se ne esistono già
            if (ordersOfCurrentYear.Count != 0)
            {
                //Estraggo il progressivo corrente dell'ultimo ordine creato
                var lastOrderNoProgress = ordersOfCurrentYear.OrderBy(o => o.No).Last().No.Substring(3, 4);
                //Converto in int
                var lastOrderNoProgressInt = Convert.ToInt32(lastOrderNoProgress) + 1;
                //Genero il nuovo progressivo
                var newOrderNo = lastOrderNoProgressInt.ToString().PadLeft(4, '0');
                //Genero il nuovo protocollo
                lastOrderNo = $"O{DateTime.Now.Year.ToString().Substring(2, 2)}{newOrderNo}";
            }

            return lastOrderNo;
        }

        // POST: Sales/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrderViewModel vmToUpdate)
        {

            try
            {
                _context.Orders.Update(vmToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = true;
                ViewBag.ErrorMessage = ex.Message;
                return View(vmToUpdate);
            }
        }

        // GET: Sales/Orders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var county = await _context.Orders.FindAsync(id);
            if (county == null)
            {
                return NotFound();
            }

            return View(county);
        }

        // POST: Sales/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var county = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(county);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
