using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public int AppointmentId { get; set; }
        public int PaymentAlternativeId { get; set; }
        public Customer Customer { get; set; }
        public Appointment Appointment { get; set; }
        public PaymentAlternative PaymentAlternative { get; set; }
    }
}