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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
