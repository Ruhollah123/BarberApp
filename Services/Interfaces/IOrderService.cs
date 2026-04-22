using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IOrderService
    {
        Task AddOrderAsync(Order order);
        Task CheckoutAsync(int customerId, List<Product> products, List<Appointment> appointments);
    }
}
