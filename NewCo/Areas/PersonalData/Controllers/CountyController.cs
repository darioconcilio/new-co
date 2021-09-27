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
    public class CountyController : Controller
    {
        IDatabaseService _IDbService;

        public CountyController(IDatabaseService IDbService)
        {
            _IDbService = IDbService;
        }

        //Approccio "Brutto" (Folle!!!)
        /*public IActionResult Index()
        {
            var context = new List<County>();

            var conn = new SqlConnection("");
            conn.Open();

            var cmd = new SqlCommand("SELECT * FROM [County]", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
                context.Add(new County(reader));

            reader.Close();
            conn.Close();

            return View(context);
        }*/

        public async Task<IActionResult> IndexAsync()
        {
            var context = await _IDbService.CountiesAsync();
            return View(context);
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            var item = await _IDbService.CountyAsync(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(County itemToUpdate)
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
            var item = new County();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(County itemToInsert)
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
            var item = await _IDbService.CountyAsync(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(County itemToDelete)
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
