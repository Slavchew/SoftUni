using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecipesApp.Models
{
    [Index(nameof(Name), IsUnique = true)] 
    public class Recipe
    {
        public Recipe()
        {
            this.Ingredients = new HashSet<RecipeIngredient>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("Title")]
        public string Name { get; set; }

        public string Description { get; set; }

        public TimeSpan? CookingTime { get; set; }

        public ICollection<RecipeIngredient> Ingredients { get; set; }
    }
}
