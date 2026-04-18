using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configurations
{
    internal class AppointmentServiceConfiguration : IEntityTypeConfiguration<AppointmentService>
    {
        public void Configure(EntityTypeBuilder<AppointmentService> builder)
        {
            builder.HasKey(am => am.Id);

            builder.HasOne(am => am.Appointment).WithMany(am => am.AppointmentServices).HasForeignKey(am => am.AppointmentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(am => am.Service).WithMany(am => am.AppointmentServices).HasForeignKey(am => am.ServiceId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
