using Microsoft.EntityFrameworkCore;
using GamingWorld.API.Domain.Models;
using GamingWorld.API.Extensions;

namespace GamingWorld.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        //Nota: DbSet no es set de establecer sino sustantivo conjunto de base de datos
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

            // Seed Data
            builder.Entity<Publication>().HasData
            (
                new Publication {Id = 1, Title = "Titulo1", Content = "Contenido1", PublicatedAt = "30/10/2021", PublicationType = 1},
                new Publication {Id = 2, Title = "Titulo2", Content = "Contenido2", PublicatedAt = "30/10/2021", PublicationType = 3}
            );

            builder.UseSnakeCaseNamingConvention();


        }
    }

}