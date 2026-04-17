using Entities.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configurations
{
    internal class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name).HasMaxLength(256).IsRequired();
            builder.Property(s => s.Description).HasMaxLength(256).IsRequired();
            builder.Property(s => s.Duration).HasMaxLength(256).IsRequired();
            builder.Property(s => s.Price).IsRequired();


        }
    }
}
