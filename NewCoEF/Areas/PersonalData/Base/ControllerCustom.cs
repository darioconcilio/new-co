using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NewCoEF.Shared.Areas.PersonalData.Models;
using System.Diagnostics;
using System.Net;

namespace NewCoEF.Areas.PersonalData.Base
{
    public class ControllerCustom : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
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
                        return "Errore nella chiamata ai servizi. Riprovare più tardi.";
                    default:
                        return "Si è verificato un errore interno non previsto. Riprovare più tardi.";
                }
            }
        }
    }
}
