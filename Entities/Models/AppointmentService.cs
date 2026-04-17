using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class AppointmentService
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int ServiceId { get; set; }
        public Appointment Appointment { get; set; }
        public Service Service { get; set; }
    }
}
