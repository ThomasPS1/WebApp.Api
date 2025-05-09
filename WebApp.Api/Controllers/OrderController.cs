using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Entity.Models;
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
        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            await repository.AddOrderAsync(order);
            return Ok();
        }

        // PUT api/<OrderController>/5
        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("No content");
            }
            await repository.UpdatOrderAsync(id, order);
            return Ok();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await repository.DeleteOrderAsync(id);
            return Ok();
        }
    }
}