using GamingWorld.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GamingWorld.API.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Publication> Publications { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Premium).IsRequired();

            builder.Entity<User>().HasData
            (
                new User { Id = 1, Username = "Fjorpa", Email = "fjorpa@hotmail.com", Password = "123456", Premium = true},
                new User { Id = 2, Username = "GoldenX", Email = "goldenx@teyapeo.pe", Password = "helpme", Premium = false},
                new User { Id = 3, Username = "RatPalyer", Email = "minecra@gmail.com", Password = "awadecoco", Premium = true},
                new User { Id = 4, Username = "Loel76", Email = "loel76@hotmail.es", Password = "xdxdxd", Premium = false}
            );
            
            //Publications

            //Constraints
            builder.Entity<Publication>().ToTable("Publications");
            builder.Entity<Publication>().HasKey(p => p.Id);
            builder.Entity<Publication>().Property(p => p.Title).IsRequired();
            builder.Entity<Publication>().Property(p => p.Content).IsRequired();
            builder.Entity<Publication>().Property(p => p.PublicatedAt).IsRequired();
            builder.Entity<Publication>().Property(p => p.PublicationType).IsRequired();
            builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            //Relationships

            // Seed Data
            //builder.Entity<Publication>().HasData();
        }
    }
}