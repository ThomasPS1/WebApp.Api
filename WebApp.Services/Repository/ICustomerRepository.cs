using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Entity.Dto;
using WebApp.Entity.Models;

namespace WebApp.Services.Repository
{
    public interface ICustomerRepository
    {
        Task <List<CustomerResponseDto>> GetAllCustomerAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(int id, Customer customer);
        Task DeleteCustomerAsync(int id);

    }
}

