using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<Appointment> AddAppointmentsAsync(int customerId, DateTime dateTime);
        Task<List<Appointment>> GetAllAppointmentsAsync();
        Task DeleteAppointmentsAsync(int id);
    }
}