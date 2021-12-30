using Microsoft.EntityFrameworkCore;

namespace RecipesApp.Models
{
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext()
        {

        }

        public RecipesDbContext(DbContextOptions<RecipesDbContext> options)
            : base(options)
        {

        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Recipes;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(x => new { x.RecipeId, x.IngredientId });
        }
    }
}
