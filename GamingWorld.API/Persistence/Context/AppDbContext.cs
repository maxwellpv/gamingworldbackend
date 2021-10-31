using GamingWorld.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GamingWorld.API.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
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
            builder.Entity<User>().Property(p => p.TypeUser).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Premiun).IsRequired();

            builder.Entity<User>().HasData
            (
                new User { Id = 001, Username = "Fjorpa", TypeUser = "Gamer", Email = "fjorpa@hotmail.com", Password = "123456", Premiun = true},
                new User { Id = 002, Username = "GoldenX", TypeUser = "Streamer", Email = "goldenx@teyapeo.pe", Password = "helpme", Premiun = false},
                new User { Id = 003, Username = "Panochita69", TypeUser = "Streamer", Email = "omevengo@yahoo.es", Password = "jaja123", Premiun = false},
                new User { Id = 004, Username = "RatPalyer", TypeUser = "Gamer", Email = "minecra@gmail.com", Password = "awadecoco", Premiun = true},
                new User { Id = 005, Username = "Loel76", TypeUser = "Streamer", Email = "loel76@hotmail.es", Password = "xdxdxd", Premiun = false}
            );
        }
    }
}