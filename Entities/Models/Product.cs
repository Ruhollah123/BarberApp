using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int BarberShopId { get; set; }
        public BarberShop BarberShop { get; set; }
    }
}
