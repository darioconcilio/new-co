using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Areas.Sales.Controllers
{
    [Area("Sales")]
    public class SalesHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
