using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task AddProductsAsync(Product productId)
        {
            await productRepository.AddProductsAsync(productId);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await productRepository.GetAllProductsAsync();
        }
    }
}
