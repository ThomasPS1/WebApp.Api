using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Entity.Data;
using WebApp.Entity.Dto;
using WebApp.Entity.Models;

namespace WebApp.Services.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customer.AddAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var custom = _context.Customer.Find(id);
            _context.Customer.Remove(custom);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CustomerResponseDto>> GetAllCustomerAsync()
        {
            var custom = await( from cust in _context.Customer 
                                join ord in 
                                _context.Order on cust.customerId equals ord.CustomerId  
                                select new CustomerResponseDto
                                {
                                    CustomerId = cust.customerId,
                                    ProductName = ord.ProductName,
                                    customName = cust.customName,
                                    OrderId = ord.OrderId,
                                    Qty = ord.Qty,
                                    UnitPrice = ord.UnitPrice,
                                    TotalPrice = ord.TotalPrice
                                }).ToListAsync();
                                    
            return custom;
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
             return await _context.Customer.FindAsync(id);
        }

        public async Task UpdateCustomerAsync(int id, Customer customer)
        {
            _context.Customer.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}


