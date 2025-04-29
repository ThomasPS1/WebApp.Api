using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderRepository repository) : ControllerBase
    {
        // GET: api/<OrderController>
        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await repository.GetAllOrderAsync());
        }

        // GET api/<OrderController>/5
        [HttpGet("GetOrderById")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            return Ok(await repository.GetOrderByIdAsync(id));
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
