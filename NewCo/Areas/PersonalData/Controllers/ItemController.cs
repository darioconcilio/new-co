using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NewCo.Areas.PersonalData.Models;
using NewCo.Commons;
using NewCo.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Areas.PersonalData.Controllers
{
    [Area("PersonalData")]
    public class ItemController : Controller
    {
        //IDatabaseService _IDbService;
        IConfiguration _configuration;
        DataSet _dataSet;

        //public ItemController(IDatabaseService IDbService)
        public ItemController(IConfiguration configuration)
        {
            //_IDbService = IDbService;
            _configuration = configuration;
        }

        //public async Task<IActionResult> IndexAsync()
        public IActionResult Index()
        {
            var itemDataAdapter = new SqlDataAdapter("SELECT * FROM [Item]", _configuration.GetConnectionString("SQL"));
            //var context = await _IDbService.ItemsAsync();
            _dataSet = new DataSet();
            itemDataAdapter.Fill(_dataSet);

            //return View(context);
            return View(_dataSet.Tables[0].Rows.ToItems());
        }

        //public async Task<IActionResult> EditAsync(int id)
        public IActionResult Edit(int id)
        {
            //var item = await _IDbService.ItemAsync(id);
            var dataRows = _dataSet.Tables[0].AsEnumerable();
            var dr = dataRows.SingleOrDefault(r => r.Field<int>("ID").Equals(id));
            var item = new Item(dr);

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditAsync(Item itemToUpdate)
        public IActionResult Edit(Item itemToUpdate)
        {
            var bundle = new Bundle()
            {
                Result = false,
                Message = ""
            };

            try
            {
                var dataRows = _dataSet.Tables[0].AsEnumerable();
                var dr = dataRows.SingleOrDefault(r => r.Field<int>("ID").Equals(itemToUpdate.Id));
                
                itemToUpdate.UpdateDataRow(ref dr);

                _dataSet.AcceptChanges();
                
            }
            catch(Exception ex)
            {
                bundle.Result = false;
                bundle.Message = ex.Message;

                ViewBag["Error"] = bundle.Result;
                return View(itemToUpdate);
            }

            return RedirectToAction(nameof(Index));

            /*
             * var bundle = await _IDbService.UpdateAsync(itemToUpdate);

            if (!bundle.Result)
            {
                ViewBag["Error"] = bundle.Result;
                return View(itemToUpdate);
            }
            else
                return RedirectToAction(nameof(Index));
            */
        }

        /*
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
        */
    }
}
