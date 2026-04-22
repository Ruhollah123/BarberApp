using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class AppointmentService(IAppointmentRepository appointmentRepository) : IAppointmentService
    {
        public async Task<Appointment> AddAppointmentsAsync(int customerId, DateTime dateTime)
        {
            var newAppointment = new Appointment
            {
                CustomerId = customerId,
                DateTime = dateTime
            };

            await appointmentRepository.AddAppointmentsAsync(newAppointment);
            return newAppointment;
        }

        public async Task DeleteAppointmentsAsync(int id)
        {
            await appointmentRepository.DeleteAppointmentsAsync(id);
        }

        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await appointmentRepository.GetAllAppointmentsAsync();
        }
    }
}