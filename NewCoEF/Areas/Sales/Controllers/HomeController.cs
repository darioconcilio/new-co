using Microsoft.AspNetCore.Mvc;
using NewCoEF.Areas.PersonalData.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Areas.Sales.Controllers
{
    [Area("Sales")]
    public class HomeController : ControllerCustom
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
