using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IServicesService
    {
        Task AddServicesAsync(Service serviceId);
        Task<List<Service>> GetAllServicesAsync();
        Task DeleteServicesAsync(int id);
    }
}