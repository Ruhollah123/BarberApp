using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Configurations
{
    internal class PaymentAlternativeConfiguration : IEntityTypeConfiguration<PaymentAlternative>
    {
        public void Configure(EntityTypeBuilder<PaymentAlternative> builder)
        {
            builder.HasKey(pa => pa.Id);

            builder.Property(pa => pa.Name).IsRequired().HasMaxLength(256);
        }
    }
}
