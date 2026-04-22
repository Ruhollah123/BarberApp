using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace EFCore.Repositories
{
    public class AppointmentRepository(BarberAppDbContext context) : IAppointmentRepository
    {
        public async Task<Appointment> AddAppointmentsAsync(Appointment appointment)
        {
            await context.Appointments.AddAsync(appointment);
            await context.SaveChangesAsync();
            return appointment;
        }

        public async Task DeleteAppointmentsAsync(int id)
        {
            var appointment = await context.Appointments.FindAsync(id);

            if (appointment != null)
            {
                context.Appointments.Remove(appointment);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await context.Appointments.ToListAsync();
        }
    }
}
