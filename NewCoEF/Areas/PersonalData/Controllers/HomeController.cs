﻿using Microsoft.AspNetCore.Mvc;
using NewCoEF.Areas.PersonalData.Base;
using System;

namespace NewCoEF.Areas.PersonalData.Controllers
{
    [Area("PersonalData")]
    public class HomeController : ControllerCustom
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SimulateError()
        {
            throw new Exception("Errore simulato sotto l'area PersonalData dal controller");
            return View();
        }
    }
}
