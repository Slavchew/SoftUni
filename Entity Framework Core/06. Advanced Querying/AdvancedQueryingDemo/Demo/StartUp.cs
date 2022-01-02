using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Z.EntityFramework.Plus;

namespace Demo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var db = new MusicXContext();

            
        }

        private static void ConcurrencyCheck(MusicXContext db)
        {
            var song = db.Songs
                            .Where(x => x.Name.Contains("осъдени"))
                            .FirstOrDefault();
            song.Name = song.Name + "1";

            var db2 = new MusicXContext();
            var song2 = db2.Songs
                            .Where(x => x.Name.Contains("осъдени"))
                            .FirstOrDefault();
            song2.Name = song2.Name + "2";

            db.SaveChanges();

            try
            {
                db2.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                var db3 = new MusicXContext();
                var song3 = db3.Songs
                            .Where(x => x.Name.Contains("осъдени"))
                            .FirstOrDefault();
                song3.Name = song3.Name + "2";
                db3.SaveChanges();
            }
        }

        private static void TypesOfLoading(MusicXContext db)
        {
            /* Explicit Loading
            var song = db.Songs
                .Where(x => x.Name.StartsWith("Осъдени души"))
                .FirstOrDefault();

            db.Entry(song).Reference(x => x.Source).Load();
            db.Entry(song).Collection(x => x.SongMetadata).Load();

            Console.WriteLine(song.Name);
            Console.WriteLine(song.Source.Name);
            Console.WriteLine(song.SongMetadata.Count);
            */

            /* Eager Loading
            var song = db.Songs
                .Include(x => x.Source)
                .Include(x => x.SongArtists)
                .ThenInclude(x => x.Artist)
                .ThenInclude(a => a.ArtistMetadata)
                .Where(x => x.Name.StartsWith("Осъдени души"))
                .FirstOrDefault();


            Console.WriteLine(song.Name);
            Console.WriteLine(song.SongArtists.Count);
            */

            /* Lazy Loading (NEVER)
            var song = db.Songs
                .Where(x => x.Name.StartsWith("Осъдени души"))
                .FirstOrDefault();

            Console.WriteLine(song.Name);
            Console.WriteLine(song.Source.Name);
            Console.WriteLine(song.SongMetadata.Select(x => x.Type).FirstOrDefault())
            */


            // N+1 Problem only with Lazy Loading
            var songs = db.Songs
                .Where(s => s.Name.Contains("а") || s.Name.Contains("е"))
                .ToList();

            foreach (var s in songs)
            {
                Console.WriteLine($"{s.Name} => {s.Source.Name} => {s.SongArtists.Count}");
            }

        }

        private static void BulkOperationWithZEFPlusPackage(MusicXContext db)
        {
            // db.SongMetadata.Where(x => x.SongId <= 15).Delete();

            db.Songs.Where(s => s.Name.Contains("а") || s.Name.Contains("е"))
                .Update(x => new Song { Name = x.Name + "(BG)" });
        }

        private static void UseRawSQLQueriesAndTestForSqlInjection(MusicXContext db)
        {
            var input = Console.ReadLine();
            // ' OR 1=1 --
            // and others


            var songs = db.Songs
                .FromSqlRaw("SELECT * FROM [Songs] WHERE [Name] LIKE {0}", input);

            foreach (var song in songs)
            {
                Console.WriteLine(song.Name);
            }
        }
    }
}
