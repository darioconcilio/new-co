using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using NewCoEF.Shared.Areas.PersonalData.Models;
using System;
using System.Diagnostics;
using System.Net;

namespace NewCoEF.Areas.PersonalData.Base
{
    public class BaseController : Controller
    {
        private readonly IStringLocalizer<BaseController> _localizer;

        public BaseController()
        {
            var prova = "";
        }

        public void GetTranslations()
        {
            ViewData["BackToList"] = _localizer["BackToList"].Value;
            ViewData["CreateNew"] = _localizer["CreateNew"].Value;
            ViewData["Delete"] = _localizer["Delete"].Value;
            ViewData["Details"] = _localizer["Details"].Value;
            ViewData["Edit"] = _localizer["Edit"].Value;
        }

        public BaseController(IStringLocalizer<BaseController> localizer)
        {
            _localizer = localizer;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorMessage = this.ErrorMessage
            });
        }

        /// <summary>
        /// Error custom message
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();

                switch (exceptionHandlerFeature?.Error)
                {
                    case WebException we:
                        return $"{we.Message}\nErrore nella chiamata ai servizi. Riprovare più tardi.";
                    default:
                        return "Errore inaspettato, riprovare più tardi.";
                }
            }
        }
    }
}
