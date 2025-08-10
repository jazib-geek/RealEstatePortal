using Microsoft.EntityFrameworkCore;
using RealEstate.Domain;

namespace RealEstate.Infrastructure
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Using Composite key for Favorites (so that the pair stays unique)
            modelBuilder.Entity<Favorite>()
                .HasKey(f => new { f.UserId, f.PropertyId });

            // Relationships
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Property)
                .WithMany(p => p.Favorites)
                .HasForeignKey(f => f.PropertyId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
