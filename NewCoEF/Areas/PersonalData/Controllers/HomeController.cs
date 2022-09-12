using Microsoft.AspNetCore.Mvc;
using NewCoEF.Areas.PersonalData.Base;

namespace NewCoEF.Areas.PersonalData.Controllers
{
    [Area("PersonalData")]
    public class HomeController : ControllerCustom
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
