using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace EFCore.Repositories
{
    public class ServicesRepository(BarberAppDbContext context) : IServicesRepository
    {
        public async Task AddServicesAsync(Service serviceId)
        {
            await context.Services.AddAsync(serviceId);
        }

        public async Task DeleteServicesAsync(int serviceId)
        {
            var serviceToDelete = await context.Services.FindAsync(serviceId);

            if (serviceToDelete != null)
            {
                context.Remove(serviceToDelete);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Service>> GetAllServicesAsync()
        {
            return await context.Services.ToListAsync();
        }
    }
}