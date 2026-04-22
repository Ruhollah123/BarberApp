using Entities.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Services.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task AddProductsAsync(Product productId);
    }
}
