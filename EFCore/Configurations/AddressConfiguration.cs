using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configurations
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Street).IsRequired().HasMaxLength(256);
            builder.Property(a => a.ZipCode).IsRequired().HasMaxLength(256);
            builder.Property(a => a.City).IsRequired().HasMaxLength(256);




            builder.HasOne(a => a.BarberShop).WithMany(b => b.Addresses).HasForeignKey(a => a.BarberShopId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
