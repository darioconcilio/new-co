using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCoEF.Areas.PersonalData.Models;
using NewCoEF.Areas.Sales.Models;
using NewCoEF.Areas.Sales.ViewModels;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCoEF.Areas.Sales.Controllers
{
    [Area("Sales")]
    public class OrderLinesController : Controller
    {
        private readonly NewCoEFDbContext _context;

        public OrderLinesController(NewCoEFDbContext context)
        {
            _context = context;
        }

        #region OrderLine

        public async Task<int> getLastOrderLineNoAsync(Guid orderId)
        {
            //Recupero tutte le righe dell'ordine corrente
            var orderLines = await _context.OrderLines.Where(r => r.OrderId == orderId).ToListAsync();

            var lastOrderLineNo = orderLines.OrderBy(l => l.LineNo).LastOrDefault()?.LineNo + 1 ?? 1; //Coalesce operator

            return lastOrderLineNo;
        }

        public async Task<IActionResult> CreateAsync(Guid orderId)
        {
            var item = new OrderLine();

            //Assegno l'ordine
            item.OrderId = orderId;
            //Assego il numero riga alla nuova riga
            item.LineNo = await getLastOrderLineNoAsync(orderId);

            var order = await _context.Orders.FindAsync(orderId);

            OrderLineViewModel vm = new OrderLineViewModel(item)
            {
                //Caricamento delle dropdown
                Items = await _context.Items.ToListAsync(),
                OrderRef = order
            };

            vm.Items.Insert(0, new Item()
            {
                Id = Guid.Empty,
                Description = "Seleziona un articolo"
            });

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(OrderLineViewModel vmToInsert)
        {
            try
            {
                await _context.AddAsync(vmToInsert);
                await _context.SaveChangesAsync();

                ViewBag.Error = false;
                ViewBag.ErrorMessage = "";

                return RedirectToAction("Edit", "Orders", new { id = vmToInsert.OrderId });
            }
            catch (Exception ex)
            {
                ViewBag.Error = true;

                StringBuilder sb = new StringBuilder(ex.Message);

                if (ex.InnerException != null)
                {
                    sb.AppendLine(ex.InnerException.Message);
                }

                ViewBag.ErrorMessage = sb.ToString();

                return View(vmToInsert);
            }
        }

        public async Task<IActionResult> EditAsync(Guid orderId, Guid id)
        {
            var item = await _context.OrderLines.FindAsync(new { orderId, id });

            var order = await _context.Orders.FindAsync(orderId);

            OrderLineViewModel vm = new OrderLineViewModel(item)
            {
                //Caricamento delle dropdown
                Items = await _context.Items.ToListAsync(),
                OrderRef = order
            };

            vm.Items.Insert(0, new Item()
            {
                Id = Guid.NewGuid(),
                Description = "Seleziona un articolo"
            });

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(OrderLineViewModel vmToUpdate)
        {
            try
            {
                _context.Update(vmToUpdate);
                await _context.SaveChangesAsync();

                ViewBag.Error = false;
                ViewBag.ErrorMessage = "";

                return RedirectToAction("Edit", "Orders", new { id = vmToUpdate.OrderId });
            }
            catch (Exception ex)
            {
                ViewBag.Error = true;
                ViewBag.ErrorMessage = ex.Message;
                return View(vmToUpdate);
            }
        }

        public async Task<IActionResult> DeleteAsync(Guid orderId, Guid id)
        {
            var item = await _context.OrderLines.FindAsync(new { orderId, id });

            var order = await _context.Orders.FindAsync(orderId);

            OrderLineViewModel vm = new OrderLineViewModel(item)
            {
                OrderRef = order,
                ItemRef = await _context.Items.FindAsync(item.ItemId)
            };

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(OrderLineViewModel itemToDelete)
        {
            try
            {
                _context.Remove(itemToDelete);
                await _context.SaveChangesAsync();

                ViewBag.Error = false;
                ViewBag.ErrorMessage = "";

                return RedirectToAction("Edit", "Order", new { id = itemToDelete.OrderId });
            }
            catch (Exception ex)
            {
                ViewBag.Error = true;
                ViewBag.ErrorMessage = ex.Message;
                return View(itemToDelete);
            }
        }

        #endregion
    }
}
