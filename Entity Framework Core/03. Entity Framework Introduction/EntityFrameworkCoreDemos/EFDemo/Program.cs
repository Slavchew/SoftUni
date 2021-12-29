using EFDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MusicXContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=MusicX;Integrated Security=true");
            var db = new MusicXContext(optionsBuilder.Options);

            var artists = db.Artists.Select(x => new
            {
                x.Name,
                SongStartWithACount = x.SongArtists.Count(s => s.Song.Name.StartsWith("A"))
            }).OrderByDescending(x => x.SongStartWithACount).Take(100).ToList();

            foreach (var artist in artists)
            {
                Console.WriteLine($"{artist.Name} => {artist.SongStartWithACount}");
            }
        }
    }
}
