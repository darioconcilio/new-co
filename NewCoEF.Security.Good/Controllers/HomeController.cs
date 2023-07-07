using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewCoEF.Security.Good.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Security.Good.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //XSRF o CSRF (cross-site request forgery)
        public IActionResult Api(string Input_Email, string Input_Password, string Input_RememberMe)
        {
            ViewData["Email"] = Input_Email;
            ViewData["Password"] = Input_Password;
            ViewData["RememberMe"] = Input_RememberMe;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
