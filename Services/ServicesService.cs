using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ServicesService(IServicesRepository servicesRepository) : IServicesService
    {
        public async Task AddServicesAsync(Service serviceId)
        {
            await servicesRepository.AddServicesAsync(serviceId);
        }

        public async Task DeleteServicesAsync(int id)
        {
            await servicesRepository.DeleteServicesAsync(id);
        }

        public async Task<List<Service>> GetAllServicesAsync()
        {
            return await servicesRepository.GetAllServicesAsync();
        }
    }
}