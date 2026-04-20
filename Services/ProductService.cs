using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    internal class ProductService(IProductRepository productRepository) : IProductService
    {
        //public async Task<Product> GetProductByIdAsync()
        //{
        //    return await
        //}
    }
}
