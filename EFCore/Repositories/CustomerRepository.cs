using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Repositories
{
    internal class CustomerRepository(BarberAppDbContext context) : ICustomerRepository
    {
        public async Task AddCustomerAsync(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetCustomerProfileAsync()
        {
            return await context.Customers.ToListAsync();
        }
    }
}
