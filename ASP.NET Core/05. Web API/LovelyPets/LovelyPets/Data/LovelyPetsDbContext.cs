namespace LovelyPets.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class LovelyPetsDbContext : DbContext
    {
        public LovelyPetsDbContext(DbContextOptions<LovelyPetsDbContext> options) 
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasMany(u => u.Pets)
                .WithOne(p => p.Owner)
                .HasForeignKey(p => p.OwnerId);
        }
    }
}