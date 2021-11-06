using GamingWorld.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GamingWorld.API.Users.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users.Domain.Models.User> Users { get; set; }
      
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Users
            builder.Entity<Users.Domain.Models.User>().ToTable("Users");
            builder.Entity<Users.Domain.Models.User>().HasKey(p => p.Id);
            builder.Entity<Users.Domain.Models.User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Users.Domain.Models.User>().Property(p => p.Username).IsRequired().HasMaxLength(30);
            builder.Entity<Users.Domain.Models.User>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<Users.Domain.Models.User>().Property(p => p.Password).IsRequired().HasMaxLength(30);
            builder.Entity<Users.Domain.Models.User>().Property(p => p.Premium).IsRequired();
            
            builder.Entity<Users.Domain.Models.User>().HasData
            (
                new Users.Domain.Models.User { Id = 1, Username = "Fjorpa", Email = "fjorpa@hotmail.com", Password = "123456", Premium = true},
                new Users.Domain.Models.User { Id = 2, Username = "GoldenX", Email = "goldenx@teyapeo.pe", Password = "helpme", Premium = false},
                new Users.Domain.Models.User { Id = 3, Username = "RatPalyer", Email = "minecra@gmail.com", Password = "awadecoco", Premium = true},
                new Users.Domain.Models.User { Id = 4, Username = "Loel76", Email = "loel76@hotmail.es", Password = "xdxdxd", Premium = false}
            );
            

            builder.UseSnakeCaseNamingConvention();

        }
    }
}