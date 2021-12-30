using System;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Models;

namespace RecipesApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new RecipesDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var recipe = new Recipe
            {
                Name = "Musaka",
                Description = "Traditional Bulgarian/Turkish meal.",
                CookingTime = new TimeSpan(2, 3, 4),
                Ingredients =
                {
                    new RecipeIngredient
                    {
                        Ingredient = new Ingredient { Name = "Potatto" },
                        Quantity = 2000
                    },
                    new RecipeIngredient
                    {
                        Ingredient = new Ingredient { Name = "Meat" },
                        Quantity = 1000
                    }
                }
            };

            db.Recipes.Add(recipe);

            db.SaveChanges();
        }
    }
}
