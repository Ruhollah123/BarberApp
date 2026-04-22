using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class OrderService(IOrderRepository orderRepository) : IOrderService
    {

        public async Task AddOrderAsync(Order order)
        {
            await orderRepository.AddOrderAsync(order);
        }

        public async Task CheckoutAsync(int customerId, List<Product> products, List<Appointment> appointments)
        {
            decimal total = products.Sum(p => p.Price);

            var appointmentId = appointments.FirstOrDefault()?.Id ?? 0; 

            var newOrder = new Order()
            {
                OrderDate = DateTime.Now,
                TotalAmount = total,
                AppointmentId = appointmentId,
                PaymentAlternativeId = 1
            };

            await orderRepository.AddOrderAsync(newOrder);
        }
    }
}
