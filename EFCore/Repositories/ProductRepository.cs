using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Repositories
{
    public class ProductRepository(BarberAppDbContext context) : IProductRepository
    {
        public async Task AddProductsAsync(Product productId)
        {
            await context.AddAsync(productId);
            await context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
           return await context.Products.ToListAsync();
        }
    }
}
