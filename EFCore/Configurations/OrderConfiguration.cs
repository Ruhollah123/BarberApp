using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.OrderDate).IsRequired();
            builder.Property(o => o.TotalAmount).IsRequired();

            builder.HasOne(o => o.Appointment).WithMany(am => am.Orders).HasForeignKey(o => o.AppointmentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(o => o.PaymentAlternative).WithMany(pa => pa.Orders).HasForeignKey(o => o.PaymentAlternativeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
