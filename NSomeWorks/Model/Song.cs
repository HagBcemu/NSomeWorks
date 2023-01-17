using System;
using System.Collections.Generic;
using System.Text;
using NSomeWorks.Model;

namespace NSomeWorks
{
    class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Duration { get; set; }

        public DateTime ReleasedDate { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual List<ArtistSong> ArtistSong { get; set; } = new List<ArtistSong>();
    }
}
