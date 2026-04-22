using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    internal class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {
        public async Task AddCustomerAsync(Customer customer)
        {
            await customerRepository.AddCustomerAsync(customer);
        }

        public async Task<List<Customer>> GetCustomerProfileAsync()
        {
            return await customerRepository.GetCustomerProfileAsync();
        }
    }
}
