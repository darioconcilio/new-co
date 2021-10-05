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

            CustomerViewModel vm = new CustomerViewModel(item)
            {
                //Caricamento delle dropdown
                Countries = await _IDbService.CountriesAsync(),
                Counties = await _IDbService.CountiesAsync()
            };

            vm.Counties.Insert(0, new County()
            {
                ID = 9999,
                Name = "Seleziona una provincia"
            });

            vm.Countries.Insert(0, new Country()
            {
                ID = 9999,
                Name = "Seleziona un paese"
            });

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(CustomerViewModel vmToUpdate)
        {
            var bundle = await _IDbService.UpdateAsync(vmToUpdate); //Magia della OOP!!! :-)

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

        public IActionResult Create()
        {
            var item = new Customer();
            CustomerViewModel vm = new CustomerViewModel(item);

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(CustomerViewModel vmToInsert)
        {
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
                return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var item = await _IDbService.CustomerAsync(id);

            ViewBag.Error = false;
            ViewBag.ErrorMessage = "";

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(Customer itemToDelete)
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
    }
}
