using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSomeWorks.Model;

namespace NSomeWorks.ModelConfiguration
{
    class ArtistSongConfiguration : IEntityTypeConfiguration<ArtistSong>
    {
        public void Configure(EntityTypeBuilder<ArtistSong> builder)
        {
            builder.HasKey(c => new { c.ArtistId, c.SongId });
            builder.Property(p => p.ArtistId).IsRequired();
            builder.Property(p => p.SongId).IsRequired();

            builder.HasOne(s => s.Artist)
              .WithMany(g => g.ArtistSong)
              .HasForeignKey(s => s.ArtistId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.Song)
              .WithMany(g => g.ArtistSong)
              .HasForeignKey(s => s.SongId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<ArtistSong>()
            {
                new ArtistSong { ArtistId = 1, SongId = 1 },
                new ArtistSong { ArtistId = 1, SongId = 2 },
                new ArtistSong { ArtistId = 1, SongId = 3 },
                new ArtistSong { ArtistId = 2, SongId = 3 },
                new ArtistSong { ArtistId = 2, SongId = 5 },
                new ArtistSong { ArtistId = 3, SongId = 2 },
                new ArtistSong { ArtistId = 3, SongId = 4 },
                new ArtistSong { ArtistId = 3, SongId = 3 },
                new ArtistSong { ArtistId = 4, SongId = 1 },
                new ArtistSong { ArtistId = 4, SongId = 4 },
                new ArtistSong { ArtistId = 4, SongId = 5 },
                new ArtistSong { ArtistId = 5, SongId = 4 },
                new ArtistSong { ArtistId = 5, SongId = 1 },
            });
        }
    }
}
