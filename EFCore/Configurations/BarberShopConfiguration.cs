using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configurations
{
    internal class BarberShopConfiguration : IEntityTypeConfiguration<BarberShop>
    {
        public void Configure(EntityTypeBuilder<BarberShop> builder)
        {
            builder.HasKey(bs => bs.Id);

            builder.Property(bs => bs.Name).IsRequired().HasMaxLength(256);
            builder.Property(bs => bs.OpeningHours).IsRequired().HasMaxLength(50);
        }
    }
}
