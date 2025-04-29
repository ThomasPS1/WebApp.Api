using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Api.Controllers;
using WebApp.Entity.Data;
using WebApp.Entity.Models;
using WebApp.Services.Repository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerRepository repository) : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            return Ok(await repository.GetAllCustomerAsync());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            return Ok(await repository.GetCustomerByIdAsync(id));
        }

        // POST api/<EmployeeController>
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Customer customer)
        {
            await repository.AddCustomerAsync(customer);
            return Ok();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("No Content for the request");
            }
            await repository.UpdateCustomerAsync(id, customer);
            return Ok();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await repository.DeleteCustomerAsync(id);
            return Ok();
        }
    }
}
