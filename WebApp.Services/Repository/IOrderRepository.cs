using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Entity.Models;

namespace WebApp.Services.Repository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrderAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task AddOrderAsync(Order order);
        Task UpdatOrderAsync(int id, Order order);
        Task DeleteOrderAsync(int id);

    }
}
