using ECommerceAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Contexts
{
    public class EcomDbContext : DbContext
    {
        public EcomDbContext(DbContextOptions<EcomDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users");
            modelBuilder.Entity<User>()
                .Property(s => s.Firstname)
                .IsRequired(true);
            modelBuilder.Entity<User>()
                .Property(s => s.Lastname)
                .IsRequired(true);

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        UserId = Guid.NewGuid(),
                        Firstname = "Victor",
                        Lastname = "Benedicto"
                    },
                    new User
                    {
                        UserId = Guid.NewGuid(),
                        Firstname = "Elisha",
                        Lastname = "Rebucas"
                    },
                    new User
                    {
                        UserId = Guid.NewGuid(),
                        Firstname = "Caloy",
                        Lastname = "Nolimark"
                    }
                );

        }
    }


}
    