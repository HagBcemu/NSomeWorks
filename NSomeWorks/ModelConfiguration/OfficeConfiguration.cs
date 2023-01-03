using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NSomeWorks
{
    class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.Property(p => p.OfficeId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Location).IsRequired().HasMaxLength(100);

            builder.HasData(new List<Office>()
            {
                new Office() { OfficeId = 1, Title = "SQL Developers", Location = "Kharkiv" },
            });
        }
    }
}
