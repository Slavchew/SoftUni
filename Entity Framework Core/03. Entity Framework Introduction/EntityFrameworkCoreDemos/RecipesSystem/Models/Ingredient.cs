using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesSystem.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public double Amount { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
