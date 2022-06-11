using System;

using Microsoft.AspNetCore.Mvc;

using MovieDeckApi.Models;

namespace MovieDeckApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet]
        public Movie GetMovie()
        {
            return new Movie
            {
                Id = 1,
                Title = "Star Wars: A New Hope (Episode IV)",
                Plot = @"Amid a galactic civil war, Rebel Alliance spies have stolen plans to the Galactic Empire's Death Star, a massive space station capable of destroying entire planets. Imperial Senator Princess Leia Organa of Alderaan, secretly one of the Rebellion's leaders, has obtained its schematics, but her starship is intercepted by an Imperial Star Destroyer under the command of the ruthless Darth Vader. Before she is captured, Leia hides the plans in the memory system of astromech droid R2-D2, who flees in an escape pod to the nearby desert planet Tatooine alongside his companion, protocol droid C-3PO.",
                ReleaseDate = new DateTime(1977, 5, 25),
            };
        }
    }
}
