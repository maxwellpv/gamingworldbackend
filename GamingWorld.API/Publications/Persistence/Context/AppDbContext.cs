using GamingWorld.API.Publications.Domain.Models;
using GamingWorld.API.UserProfiles.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GamingWorld.API.Publications.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Publication> Publications { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
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
            
            builder.UseSnakeCaseNamingConvention();

        }
    }
}