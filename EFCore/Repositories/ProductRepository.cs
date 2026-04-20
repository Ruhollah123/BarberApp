using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Repositories
{
    internal class ProductRepository(BarberAppDbContext context) : IProductRepository
    {

    }
}
