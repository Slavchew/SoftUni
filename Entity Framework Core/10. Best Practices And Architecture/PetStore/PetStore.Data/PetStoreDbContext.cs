using Microsoft.EntityFrameworkCore;
using PetStore.Common;
using PetStore.Models;
using System.Reflection;

namespace PetStore.Data
{
    public class PetStoreDbContext : DbContext
    {
        public PetStoreDbContext()
        {

        }

        public PetStoreDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Breed> Breeds { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientProduct> ClientProducts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Town> Towns { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfiguration.DefaultConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetStoreDbContext).Assembly);
        }
    }
}
