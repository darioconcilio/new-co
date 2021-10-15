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
            List<Order> context = await _IDbService.OrdersAsync();
            return View(context);
        }

        public async Task<IActionResult> EditAsync(string no)
        {
            Order item = await _IDbService.OrderAsync(no);

            OrderViewModel vm = new OrderViewModel(item)
            {
                //Caricamento delle righe
                Lines = await _IDbService.OrderLinesAsync(no),

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
            item.No = await _IDbService.GetLastOrderNoAsync();
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
            var bundle = await _IDbService.InsertAsync(vmToInsert);

            using(var scope=new TransactionScope())
            {

            }

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            if (!bundle.Result)
            {
                ViewBag.Error = true;
                ViewBag.ErrorMessage = bundle.Message;
                return View(vmToInsert);
            }
            else
                return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteAsync(string no)
        {
            var item = await _IDbService.OrderAsync(no);

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(Order itemToDelete)
        {
            var bundle = new Bundle
            {
                Result = true
            };

            //Il TransactionScope permette di raggruppare tutte le chiamate, anche async in una 
            //unica transazione
            using (var scope = new TransactionScope())
            {
                //Prima elimino le righe dell'ordine
                foreach (var lineToDelete in itemToDelete.Lines)
                {
                    var bundleLines = await _IDbService.DeleteAsync(lineToDelete);
                    bundle = bundleLines;

                    //Se incontro un problema allora mi fermo nel ciclo
                    if (!bundleLines.Result)
                        break;
                }

                //Le righe sono state eliminate? Allora elimino la testata
                if (bundle.Result)
                {
                    var bundleHeader = await _IDbService.DeleteAsync(itemToDelete);
                    bundle = bundleHeader;
                }

                //Tutto è andato per il meglio, allora COMMIT
                //altrimenti ROLLBACK automatico
                if (bundle.Result)
                    scope.Complete();
            }

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
    }
}
