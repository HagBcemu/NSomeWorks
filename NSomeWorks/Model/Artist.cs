using System;
using System.Collections.Generic;
using System.Text;
using NSomeWorks.Model;

namespace NSomeWorks
{
    class Artist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string InstagramUrl { get; set; }

        public virtual List<ArtistSong> ArtistSong { get; set; } = new List<ArtistSong>();
    }
}
