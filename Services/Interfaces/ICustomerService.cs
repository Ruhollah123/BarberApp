using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(Customer customer);
        Task<List<Customer>> GetCustomerProfileAsync(); 
    }
}