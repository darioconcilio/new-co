using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NewCoEF.Models;
using System.Diagnostics;
using System.Net;

namespace NewCoEF.Base
{
    public class ControllerCustom : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode = null)
        //public IActionResult Error()
        {
            if (statusCode.HasValue)
            {
                if (statusCode == 404 || statusCode == 500)
                {
                    var viewName = statusCode.ToString();
                    return View(viewName);
                }
            }

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
                        return "Errore nella chiamata ai servizi. Riprovare più tardi.";
                    default:
                        return "Si è verificato un errore interno non previsto. Riprovare più tardi.";
                }

                //NOTIFICA ERRORE
            }
        }
    }
}
