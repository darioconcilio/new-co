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
            var items = new List<Item>();

            try
            {
                items = await (from rec in context.Items
                               select rec).ToListAsync();
            }
            catch (Exception ex)
            {
                var response = new ErrorResponse(123, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    JsonConvert.SerializeObject(response));
            }

            return Ok(JsonConvert.SerializeObject(items));
        }

        // GET api/items/00000000-0000-0000-0000-000000000000
        [HttpGet("{id}")]
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
                                      JsonConvert.SerializeObject(response));
                }

            }
            catch (Exception ex)
            {
                var response = new ErrorResponse(5, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  JsonConvert.SerializeObject(response));
            }

            //Status200OK
            return Ok(JsonConvert.SerializeObject(itemFound));
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
                                          JsonConvert.SerializeObject(response));
                    }
                }

                response = new ErrorResponse(ex.HResult, message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  JsonConvert.SerializeObject(response));
            }

            return StatusCode(StatusCodes.Status201Created,
                              JsonConvert.SerializeObject(itemToCreate));
        }

        // PUT api/items
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Item itemToUpdate)
        {
            var response = new ErrorResponse();

            try
            {
                context.Items.Attach(itemToUpdate);
                context.Items.Update(itemToUpdate);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var message = ex.Message;

                response = new ErrorResponse(ex.HResult, message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  JsonConvert.SerializeObject(response));
            }

            return StatusCode(StatusCodes.Status200OK,
                              JsonConvert.SerializeObject(itemToUpdate));
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
                                      JsonConvert.SerializeObject(response));
                }

                context.Items.Remove(itemToDelete);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var message = ex.Message;

                response = new ErrorResponse(ex.HResult, message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  JsonConvert.SerializeObject(response));
            }

            return StatusCode(StatusCodes.Status204NoContent, null);
        }
    }
}
