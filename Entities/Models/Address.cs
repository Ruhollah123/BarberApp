using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public int BarberShopId { get; set; }
        public BarberShop BarberShop { get; set; }
    }
}