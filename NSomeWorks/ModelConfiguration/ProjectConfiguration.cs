using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NSomeWorks
{
    class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.ProjectId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Budget).IsRequired();
            builder.Property(p => p.StartedDate).IsRequired().HasMaxLength(7);
            builder.Property(p => p.ClientID).IsRequired();

            builder.HasOne(e => e.Client)
                .WithMany(p => p.Projects)
                .HasForeignKey(c => c.ClientID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<Project>()
            {
                new Project() { ProjectId = 1, Name = "WhatsApp", Budget = 15000, StartedDate = new DateTime(2008, 7, 6), ClientID = 1 },
                new Project() { ProjectId = 2, Name = "Эковер", Budget = 85000, StartedDate = new DateTime(2007, 2, 8), ClientID = 2 },
                new Project() { ProjectId = 3, Name = "Чук и Гик", Budget = 952040, StartedDate = new DateTime(2012, 3, 7), ClientID = 3 },
                new Project() { ProjectId = 4, Name = "Sunofabeach", Budget = 700000, StartedDate = new DateTime(2016, 5, 12), ClientID = 4 },
                new Project() { ProjectId = 5, Name = "Tesla", Budget = 600000, StartedDate = new DateTime(2000, 1, 7), ClientID = 5 },
            });
        }
    }
}
