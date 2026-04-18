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
        public int UserId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = [];
        public ICollection<Order> Orders { get; set; } = [];
    }
}
