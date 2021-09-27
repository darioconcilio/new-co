using Microsoft.AspNetCore.Mvc;
using NewCo.Areas.PersonalData.Models;
using NewCo.Areas.PersonalData.ViewModels;
using NewCo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Areas.PersonalData.Controllers
{
    [Area("PersonalData")]
    public class CustomerController : Controller
    {
        IDatabaseService _IDbService;

        public CustomerController(IDatabaseService IDbService)
        {
            _IDbService = IDbService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<Customer> context = await _IDbService.CustomersAsync();
            return View(context);
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            Customer item = await _IDbService.CustomerAsync(id);
            CustomerViewModel vm = new CustomerViewModel(item);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(CustomerViewModel vmToUpdate)
        {
            var bundle = await _IDbService.UpdateAsync(vmToUpdate); //Magia della OOP!!! :-)

            if (!bundle.Result)
            {
                ViewBag["Error"] = bundle.Result;
                return View(vmToUpdate);
            }
            else
                return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            var item = new Customer();
            CustomerViewModel vm = new CustomerViewModel(item);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(CustomerViewModel vmToInsert)
        {
            var bundle = await _IDbService.InsertAsync(vmToInsert);

            if (!bundle.Result)
            {
                ViewBag["Error"] = bundle.Result;
                return View(vmToInsert);
            }
            else
                return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var item = await _IDbService.CustomerAsync(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(Customer itemToDelete)
        {
            var bundle = await _IDbService.DeleteAsync(itemToDelete);

            if (!bundle.Result)
            {
                ViewBag["Error"] = bundle.Result;
                return View(itemToDelete);
            }
            else
                return RedirectToAction(nameof(Index));
        }
    }
}
