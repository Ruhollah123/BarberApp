using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}