using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(256);
            builder.Property(c => c.BirthDate).IsRequired().HasMaxLength(256);

            builder.HasOne(c => c.Role).WithMany(r => r.Customers).HasForeignKey(c => c.RoleId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.User).WithOne(u => u.Customer).HasForeignKey<Customer>(c => c.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}