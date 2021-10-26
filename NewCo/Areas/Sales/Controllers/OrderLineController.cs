using Microsoft.AspNetCore.Mvc;
using NewCo.Areas.PersonalData.Models;
using NewCo.Areas.Sales.Models;
using NewCo.Areas.Sales.ViewModels;
using NewCo.Commons;
using NewCo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace NewCo.Areas.Sales.Controllers
{
    [Area("Sales")]
    public class OrderLineController : Controller
    {
        IDatabaseService _IDbService;

        public OrderLineController(IDatabaseService IDbService)
        {
            _IDbService = IDbService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<Order> context = await _IDbService.OrdersAsync();
            return View(context);
        }

        #region OrderLine

        public async Task<IActionResult> CreateAsync(string orderId)
        {
            var item = new OrderLine();

            //Assegno l'ordine
            item.OrderId = orderId;
            //Assego il numero riga alla nuova riga
            item.LineNo = await _IDbService.GetLastOrderLineNoAsync(orderId);

            var orderBundle = await _IDbService.OrderAsync(orderId);
            var order = (Order)orderBundle.Value;

            OrderLineViewModel vm = new OrderLineViewModel(item)
            {
                //Caricamento delle dropdown
                Items = await _IDbService.ItemsAsync(),
                OrderRef = order
            };

            vm.Items.Insert(0, new Item()
            {
                Id = 9999,
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
            var selectedItem = await _IDbService.ItemAsync(vmToInsert.ItemId);
            vmToInsert.Description = selectedItem.Description;

            var bundle = await _IDbService.InsertAsync(vmToInsert);

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            if (!bundle.Result)
            {
                ViewBag.Error = true;
                ViewBag.ErrorMessage = bundle.Message;
                return View(vmToInsert);
            }
            else
                return RedirectToAction("Edit", "Order", new { id = vmToInsert.OrderId });
        }

        public async Task<IActionResult> EditAsync(string orderId, string id)
        {
            var item = await _IDbService.OrderLineAsync(orderId, id);

            var orderBundle = await _IDbService.OrderAsync(orderId);
            var order = (Order)orderBundle.Value;

            OrderLineViewModel vm = new OrderLineViewModel(item)
            {
                //Caricamento delle dropdown
                Items = await _IDbService.ItemsAsync(),
                OrderRef = order
            };

            vm.Items.Insert(0, new Item()
            {
                Id = 9999,
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
            var bundle = await _IDbService.UpdateAsync(vmToUpdate);

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            if (!bundle.Result)
            {
                ViewBag.Error = true;
                ViewBag.ErrorMessage = bundle.Message;
                return View(vmToUpdate);
            }
            else
                return RedirectToAction("Edit", "Order", new { orderId = vmToUpdate.OrderId });
        }

        public async Task<IActionResult> DeleteAsync(string orderId, string id)
        {
            var item = await _IDbService.OrderLineAsync(orderId, id);

            var orderBundle = await _IDbService.OrderAsync(orderId);
            var order = (Order)orderBundle.Value;

            OrderLineViewModel vm = new OrderLineViewModel(item)
            {
                //Caricamento delle dropdown
                //Items = await _IDbService.ItemsAsync(), //Questo riferimento nella Delete non mi serve
                OrderRef = order
            };

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(OrderLineViewModel itemToDelete)
        {
            var bundle = await _IDbService.DeleteAsync(itemToDelete);

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            if (!bundle.Result)
            {
                ViewBag.Error = true;
                ViewBag.ErrorMessage = bundle.Message;
                return View(itemToDelete);
            }
            else
                return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
