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
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await context.Customer.ToListAsync();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<Customer> Get(int id)
        {
            return await context.Customer.FindAsync(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task Post([FromBody] Customer customer)
        {
            context.Customer.Add(customer);
            await context.SaveChangesAsync();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Customer customer)
        {
            context.Customer.Update(customer);
            await context.SaveChangesAsync();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var custom = context.Customer.Find(id);
            context.Customer.Remove(custom);
            await context.SaveChangesAsync();
        }
    }
}
