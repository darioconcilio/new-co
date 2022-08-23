using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCoEF.Shared.Areas.PersonalData.Models;
using NewCoEF.Commons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewCoEF.Areas.PersonalData.Controllers
{

    //Specifiche dell'enum Microsoft.AspNetCore.Http.StatusCodes
    //https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.statuscodes?view=aspnetcore-3.1

    //Pagina principale di iana (Internet Assigned Numbers Authority
    //https://www.iana.org/assignments/http-status-codes/http-status-codes.xhtml

    //RFC 9110 - HTTP Semantics
    //https://www.rfc-editor.org/rfc/rfc9110.html#name-status-codes

    [Route("api/items")]
    [ApiController]
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


        // GET api/items/00000000-0000-0000-0000-000000000000
        /// <summary>
        /// Recupera uno specifico articolo
        /// </summary>
        /// <param name="id">Codice che identifica l'articolo in formato GUID</param>
        /// <response code="200">Ritorna l'articolo cercato</response>
        /// <response code="404">Se l'articolo non è stato trovato</response>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Item), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> Get(Guid id)
        {
            var itemFound = new Item();

            try
            {
                itemFound = await (from rec in context.Items
                                   where rec.Id == id
                                   select rec).FirstOrDefaultAsync();

                if (itemFound == null)
                {
                    var response = new ErrorResponse(1, $"Item {id} not found");
                    return StatusCode(StatusCodes.Status404NotFound,
                                      response);
                }

            }
            catch (Exception ex)
            {
                var response = new ErrorResponse(5, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  response);
            }

            //Status200OK
            //return Ok(JsonConvert.SerializeObject(itemFound));
            return new JsonResult(itemFound);
        }

        // POST api/items
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item itemToCreate)
        {
            var response = new ErrorResponse();

            try
            {
                if (itemToCreate.Id == Guid.Empty)
                    itemToCreate.Id = Guid.NewGuid();

                context.Items.Add(itemToCreate);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var message = ex.Message;

                if (ex.InnerException != null)
                {
                    message += $" >> {ex.InnerException.Message}";

                    if (ex.InnerException.Message.Contains("PRIMARY KEY"))
                    {
                        response = new ErrorResponse(ex.HResult, message);
                        return StatusCode(StatusCodes.Status409Conflict,
                                          response);
                    }
                }

                response = new ErrorResponse(ex.HResult, message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  response);
            }

            return StatusCode(StatusCodes.Status201Created,
                              itemToCreate);
        }

        // PUT api/items
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Item itemToUpdate)
        {
            var response = new ErrorResponse();

            try
            {
                var itemFound = await context.Items.FindAsync(itemToUpdate.Id);

                if (itemFound == null)
                {
                    response = new ErrorResponse(99, "Resource not found");
                    return StatusCode(StatusCodes.Status404NotFound,
                                      response);
                }

                context.Items.Attach(itemToUpdate);
                context.Items.Update(itemToUpdate);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var message = ex.Message;

                response = new ErrorResponse(ex.HResult, message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  response);
            }

            return StatusCode(StatusCodes.Status200OK,
                              itemToUpdate);
        }

        // DELETE api/items/00000000-0000-0000-0000-000000000000
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = new ErrorResponse();

            try
            {
                var itemToDelete = await context.Items.FindAsync(id);

                if (itemToDelete == null)
                {
                    response = new ErrorResponse(99, $"Item {id} not exists.");
                    return StatusCode(StatusCodes.Status404NotFound,
                                      response);
                }

                context.Items.Remove(itemToDelete);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var message = ex.Message;

                response = new ErrorResponse(ex.HResult, message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  response);
            }

            return StatusCode(StatusCodes.Status204NoContent, null);
        }
    }
}
