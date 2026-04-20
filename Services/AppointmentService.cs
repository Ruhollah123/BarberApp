using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    internal class AppointmentService(IAppointmentRepository appointmentRepository) : IAppointmentService
    {
        public async Task<Appointment> AddAppointmentsByIdAsync(Appointment appointment)
        {
            return await appointmentRepository.AddAppointmentsByIdAsync(appointment);
        }
    }
}