using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebApp.Api.Controllers;
using WebApp.Entity.Data;
using WebApp.Entity.Dto;
using WebApp.Entity.Models;
using WebApp.Services.Repository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerRepository repository,ILogger<CustomerController> logger, IMemoryCache cache) : ControllerBase
    {
        public const string CustomerCache = "CustomerCache";
        // GET: api/<EmployeeController>
        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            logger.LogInformation("Entered on GetAllCustomer");
            if (!cache.TryGetValue(CustomerCache, out List<CustomerResponseDto> customerData))
            {
                customerData = await repository.GetAllCustomerAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

                cache.Set(CustomerCache, customerData, cacheEntryOptions);
            }
            return Ok(customerData);

        }

        // GET api/<EmployeeController>/5
        [HttpGet("GetCustomerById")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            return Ok(await repository.GetCustomerByIdAsync(id));
        }

        // POST api/<EmployeeController>
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            await repository.AddCustomerAsync(customer);
            return Ok();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult>UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("No Content for the request");
            }
            await repository.UpdateCustomerAsync(id, customer);
            return Ok();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await repository.DeleteCustomerAsync(id);
            return Ok();
        }
    }
}
