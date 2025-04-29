using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Entity.Data;
using WebApp.Entity.Models;

namespace WebApp.Services.Repository
{
    public class OrderRepository(ApplicationDbContext context) : IOrderRepository
    {
        public async Task AddOrderAsync(Order order)
        {
            await context.Order.AddAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            var ord = context.Order.Find(id);
            context.Order.Remove(ord);
            await context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllOrderAsync()
        {
            return await context.Order.ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await context.Order.FindAsync(id);
        }

        public async Task UpdatOrderAsync(int id, Order order)
        {
            context.Order.Update(order);
            await context.SaveChangesAsync();
        }
    }
}
