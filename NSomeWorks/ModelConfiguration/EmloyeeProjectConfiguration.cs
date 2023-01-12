using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NSomeWorks
{
    class EmloyeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.Property(p => p.EmployeeProjectId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Rate).IsRequired();
            builder.Property(p => p.StartedDate).IsRequired().HasMaxLength(7);
            builder.Property(p => p.EmployeeId).IsRequired();
            builder.Property(p => p.ProjectId).IsRequired();

            builder.HasOne(e => e.Employee)
                .WithMany(p => p.EmployeeProject)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Project)
                .WithMany(p => p.EmployeeProject)
                .HasForeignKey(e => e.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
