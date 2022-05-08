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
    public class OrderController : Controller
    {
        IDatabaseService _IDbService;

        public OrderController(IDatabaseService IDbService)
        {
            _IDbService = IDbService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<OrderViewModel> context = await _IDbService.OrdersAsync();
            return View(context);
        }

        #region Order

        public async Task<IActionResult> EditAsync(string id)
        {
            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            OrderViewModel vm = null;

            var bundle = await _IDbService.OrderAsync(id);

            if (bundle.Result)
            {
                var item = (Order)bundle.Value;

                vm = new OrderViewModel(item)
                {
                    //Caricamento delle righe
                    Lines = await _IDbService.OrderLinesAsync(id),

                    //Caricamento delle dropdown
                    Customers = await _IDbService.CustomersAsync()
                };

                vm.Customers.Insert(0, new Customer()
                {
                    ID = 9999,
                    Name = "Seleziona una cliente"
                });
            }
            else
            {
                ViewBag.Error = true;
                ViewBag.ErrorMessage = bundle.Message;
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(OrderViewModel vmToUpdate)
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
                return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateAsync()
        {
            var item = new Order();

            //Assego il numero protocollo al nuovo ordine
            item.No = await _IDbService.GetNewOrderNoAsync();
            //Propongo la data di oggi
            item.Date = DateTime.Today;

            OrderViewModel vm = new OrderViewModel(item)
            {
                //Caricamento delle dropdown
                Customers = await _IDbService.CustomersAsync()
            };

            vm.Customers.Insert(0, new Customer()
            {
                ID = 9999,
                Name = "Seleziona una cliente"
            });

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(OrderViewModel vmToInsert)
        {
            var bundle = new Bundle
            {
                Result = true
            };

            var bundleHeader = await _IDbService.InsertAsync(vmToInsert);
            bundle = bundleHeader;

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            if (!bundle.Result)
            {
                ViewBag.Error = true;
                ViewBag.ErrorMessage = bundle.Message;
                return View(vmToInsert);
            }
            else
                return RedirectToAction("Edit", "Order", new { id = vmToInsert.Id });
        }

        public async Task<IActionResult> DeleteAsync(string id)
        {
            var item = await _IDbService.OrderAsync(id);
            OrderViewModel vm = null;

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            if (item.Result)
            {
                var order = (Order)item.Value;
                vm = new OrderViewModel(order)
                {
                    //Caricamento delle righe
                    Lines = await _IDbService.OrderLinesAsync(id),

                    //Caricamento delle dropdown
                    //Customers = await _IDbService.CustomersAsync() //Qui non serve
                };
            }
            else
                return RedirectToAction("Index", "Order");

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(OrderViewModel itemToDelete)
        {
            var bundle = new Bundle
            {
                Result = true
            };

            bundle = await _IDbService.DeleteCompleteAsync(itemToDelete);

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
