using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}