using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks.Model
{
    class ArtistSong
    {
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public int SongId { get; set; }

        public virtual Song Song { get; set; }
    }
}
