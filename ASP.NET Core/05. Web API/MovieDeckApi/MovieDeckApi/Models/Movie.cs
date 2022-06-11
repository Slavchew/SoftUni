using System;

namespace MovieDeckApi.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Plot { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
