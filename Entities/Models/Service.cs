using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Duration { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
