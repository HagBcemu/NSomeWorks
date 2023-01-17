using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NSomeWorks
{
    class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Duration).IsRequired();
            builder.Property(p => p.ReleasedDate).IsRequired();
            builder.Property(p => p.GenreId).IsRequired();

            builder.HasOne(s => s.Genre)
                .WithMany(g => g.Songs)
                .HasForeignKey(s => s.GenreId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<Song>()
            {
            new Song { Id = 1, Title = "Gabin", Duration = 3.5d, ReleasedDate = new DateTime(2003, 5, 6), GenreId = 1 },
            new Song { Id = 2, Title = "Blinding Lights", Duration = 7.3d, ReleasedDate = new DateTime(1999, 3, 5), GenreId = 2 },
            new Song { Id = 3, Title = "Balenciaga", Duration = 4.2d, ReleasedDate = new DateTime(2003, 2, 1), GenreId = 3 },
            new Song { Id = 4, Title = "Roses", Duration = 1.8d, ReleasedDate = new DateTime(2004, 7, 6), GenreId = 4 },
            new Song { Id = 5, Title = "Beliver", Duration = 3.7d, ReleasedDate = new DateTime(2007, 7, 7), GenreId = 5 },
            });
        }
    }
}