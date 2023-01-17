using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NSomeWorks
{
    class QueryesLINQ
    {
        public void Run()
        {
            Query1();
            Query2();
            Query3();
        }

        private void Query1()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("\nQuery 1");

                var songs = db.ArtistSong
                    .Where(a => a.Artist != null)
                    .Where(a => a.Song.Genre != null)
                    .Include(a => a.Artist)
                    .Include(g => g.Song.Genre);

                foreach (var song in songs)
                {
                    Console.WriteLine("Название песни: " + song.Song.Title + " Имя исполнителя: " + song.Artist.Name + " Название жанра песни: " + song.Song.Genre.Title);
                }

                Console.WriteLine(songs.ToQueryString());
            }
        }

        private void Query2()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("\n\nQuery 2");

                var query = from s in db.Songs
                            group s by s.Genre.Title into g
                            select new { Name = g.Key, Count = g.Count() };

                foreach (var song in query)
                {
                    Console.WriteLine(song.Name + " " + song.Count);
                }

                Console.WriteLine(query.ToQueryString());
            }
        }

        private void Query3()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Console.WriteLine("\n\nQuery 3");

                var query = db.Songs.Where(s => s.ReleasedDate > db.Artists.Min(a => a.DateOfBirth));

                foreach (var song in query)
                {
                    Console.WriteLine("Name " + song.Title + " Release: " + song.ReleasedDate.ToString("dd.MM.yyyy") + " Duration: " + song.Duration);
                }

                Console.WriteLine(query.ToQueryString());
            }
        }
    }
}
