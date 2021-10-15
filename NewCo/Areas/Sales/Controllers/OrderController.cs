﻿using Microsoft.AspNetCore.Mvc;
using NewCo.Areas.PersonalData.Models;
using NewCo.Areas.Sales.Models;
using NewCo.Areas.Sales.ViewModels;
using NewCo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
