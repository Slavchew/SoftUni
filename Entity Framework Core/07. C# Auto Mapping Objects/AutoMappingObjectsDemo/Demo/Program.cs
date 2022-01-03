using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demo.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Artist, ArtistWithCount>();
                cfg.AddProfile(new SongsToViewModelProfile());
            });
            var mapper = config.CreateMapper();

            var db = new MusicXContext();

            var inputModel = new SongViewModel 
            { 
                Name = "Test123", 
                SourceName = "utube" 
            };
            var song = mapper.Map<Song>(inputModel);

            // List<SongViewModel> songs = db.Songs.ProjectTo<SongViewModel>(config).Take(10).ToList();

            //ArtistWithCount artistViewModel = db.Artists
            //    .ProjectTo<ArtistWithCount>(config).Skip(9).FirstOrDefault();

            Print(song);

        }

        public static void Print(object artists)
        {
            Console.WriteLine(JsonConvert.SerializeObject(artists, Formatting.Indented));
        }
    }
}
