using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NSomeWorks
{
    class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.DateOfBirth).IsRequired();

            builder.HasData(new List<Artist>()
            {
                new Artist { Id = 1, Name = "Gabin", DateOfBirth = new DateTime(1973, 5, 6), Phone = "054678546", Email = "Gabin.comercial@gmail.com", InstagramUrl = "www.instagram.com/ifty/" },
                new Artist { Id = 2, Name = "Londobeat", DateOfBirth = new DateTime(1980, 3, 4), Phone = "47645624", Email = "Londobeat.comercial@gmail.com", InstagramUrl = "www.instagram.com/t" },
                new Artist { Id = 3, Name = "Panik", DateOfBirth = new DateTime(1993, 11, 10), Phone = "6544231234", Email = "Panik.comercial@gmail.com", InstagramUrl = "www.instagram.com/ftshty/" },
                new Artist { Id = 4, Name = "Radioheat", DateOfBirth = new DateTime(1988, 3, 7), Phone = "2321165778", Email = "Radioheat.comercial@gmail.com", InstagramUrl = "www.instagram.com/git" },
                new Artist { Id = 5, Name = "Arabesque", DateOfBirth = new DateTime(1974, 3, 5), Phone = "445221265", Email = "Arabesque.comercial@gmail.com", InstagramUrl = "www.instagram.com/gfty/" }
            });
        }
    }
}
