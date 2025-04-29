using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Entity.Data;
using WebApp.Entity.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ApplicationDbContext context) : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            return Ok(await context.Customer.ToListAsync());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            return Ok(await context.Customer.FindAsync(id));
        }

        // POST api/<EmployeeController>
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Customer customer)
        {
            context.Customer.Add(customer);
            await context.SaveChangesAsync();
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
            context.Customer.Update(customer);
            await context.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var custom = context.Customer.Find(id);
            context.Customer.Remove(custom);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
