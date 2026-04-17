using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class BarberShop
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string OpeningHours { get; set; } = null!;
    }
}