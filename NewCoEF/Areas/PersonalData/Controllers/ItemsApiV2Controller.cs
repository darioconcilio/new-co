using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCoEF.Commons;
using NewCoEF.Shared.Areas.PersonalData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Areas.PersonalData.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    //[Route("api/items")]
    [Route("api/v{version:apiVersion}/items")]
    
    public class ItemsApiController : ControllerBase
    {
        private readonly NewCoEFDbContext context;

        public ItemsApiController(NewCoEFDbContext context)
        {
            this.context = context;
        }

        // GET: api/items
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Item> items = null;

            try
            {
                items = await (from rec in context.Items
                               where rec.Description.ToLower().Contains("portatile")
                               select rec).ToListAsync();

                //throw new Exception("Errore interno....");
            }
            catch (Exception ex)
            {
                var response = new ErrorResponse(123, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  response);
                //return StatusCode(StatusCodes.Status500InternalServerError,
                //    new JsonResult(response));
            }

            //return Ok(JsonConvert.SerializeObject(items));
            return Ok(items);
        }
    }
}
