using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NSomeWorks
{
    class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(250);

            builder.HasData(new List<Genre>()
            {
                new Genre { Id = 1, Title = "Jazz" },
                new Genre { Id = 2, Title = "Funk" },
                new Genre { Id = 3, Title = "Reaggae" },
                new Genre { Id = 4, Title = "Latin" },
                new Genre { Id = 5, Title = "Metal" },
            });
        }
    }
}
