using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Models
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }

        public decimal Quantity { get; set; }
    }
}
