using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            this.Recipes = new HashSet<RecipeIngredient>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<RecipeIngredient> Recipes { get; set; }
    }
}
