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

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            return await _context.Customer.ToListAsync();
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


