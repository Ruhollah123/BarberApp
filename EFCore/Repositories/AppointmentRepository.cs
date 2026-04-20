using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Repositories
{
    internal class AppointmentRepository(BarberAppDbContext context) : IAppointmentRepository
    {
        public async Task AddAppointmentsByIdAsync(Appointment appointment)
        {
            await context.Appointments.AddAsync(appointment);
            await context.SaveChangesAsync();
        }
    }
}
