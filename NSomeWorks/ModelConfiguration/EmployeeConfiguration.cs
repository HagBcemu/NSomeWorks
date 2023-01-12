using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NSomeWorks
{
    class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(p => p.EmployeeId).ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.HiredDate).IsRequired().HasMaxLength(7);
            builder.Property(p => p.DateOfBirth);
            builder.Property(p => p.OfficeId).IsRequired();
            builder.Property(p => p.TitleId).IsRequired();

            builder.HasOne(e => e.Title)
                .WithMany(t => t.Employee)
                .HasForeignKey(e => e.TitleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Office)
                .WithMany(o => o.Employee)
                .HasForeignKey(e => e.OfficeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<Employee>()
            {
                new Employee() { EmployeeId = 1, FirstName = "John", LastName = "Wick", HiredDate = new DateTime(2008, 7, 6), OfficeId = 1, TitleId = 1 },
            });
        }
    }
}
