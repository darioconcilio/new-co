using Microsoft.AspNetCore.Mvc;
using NewCo.Areas.PersonalData.Models;
using NewCo.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Areas.PersonalData.Controllers
{
    [Area("PersonalData")]
    public class ItemController : Controller
    {
        IDatabaseService _IDbService;

        public ItemController(IDatabaseService IDbService)
        {
            _IDbService = IDbService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var context = await _IDbService.ItemsAsync();
            return View(context);
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            var item = await _IDbService.ItemAsync(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(Item itemToUpdate)
        {
            var bundle = await _IDbService.UpdateAsync(itemToUpdate);

            if (!bundle.Result)
            {
                ViewBag["Error"] = bundle.Result;
                return View(itemToUpdate);
            }
            else
                return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            var item = new Item();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Item itemToInsert)
        {
            var bundle = await _IDbService.InsertAsync(itemToInsert);

            if (!bundle.Result)
            {
                ViewBag["Error"] = bundle.Result;
                return View(itemToInsert);
            }
            else
                return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var item = await _IDbService.ItemAsync(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(Item itemToDelete)
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
