using GamingWorld.API.Profiles.Domain.Models;
using GamingWorld.API.Publications.Domain.Models;
using GamingWorld.API.Security.Domain.Models;
using GamingWorld.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GamingWorld.API.Shared.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Profiles
            builder.Entity<Profile>().ToTable("Profiles");
            builder.Entity<Profile>().HasKey(p => p.Id);
            builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Profile>().Property(p => p.UserId).IsRequired();
            builder.Entity<Profile>().Property(p => p.GamingLevel).IsRequired();
            builder.Entity<Profile>().Property(p => p.IsStreamer).IsRequired();
            builder.Entity<Profile>().HasMany(p => p.GameExperiences).WithOne();
            builder.Entity<Profile>().HasMany(p => p.StreamingCategories).WithOne();
            builder.Entity<Profile>().HasMany(p => p.StreamerSponsors).WithOne();
            builder.Entity<Profile>().HasMany(p => p.FavoriteGames).WithOne();
            builder.Entity<Profile>().HasMany(p => p.TournamentExperiences).WithOne();

            // Profiles: GameExperiences
            builder.Entity<GameExperience>().ToTable("GameExperiences");
            builder.Entity<GameExperience>().HasKey(ge => ge.Id);
            builder.Entity<GameExperience>().Property(ge => ge.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<GameExperience>().Property(ge => ge.GameName).IsRequired();
            builder.Entity<GameExperience>().Property(ge => ge.Time).IsRequired();
            builder.Entity<GameExperience>().Property(ge => ge.TimeUnit).IsRequired();

            // Profiles: StreamingCategories
            builder.Entity<StreamingCategory>().ToTable("StreamingCategories");
            builder.Entity<StreamingCategory>().HasKey(sc => sc.Id);
            builder.Entity<StreamingCategory>().Property(sc => sc.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<StreamingCategory>().Property(sc => sc.Name).IsRequired();

            builder.Entity<StreamingCategory>().HasData
            (
                new StreamingCategory {Id = 1, Name = "Battle Royale", ProfileId = 1},
                new StreamingCategory {Id = 2, Name = "First Person Shooter", ProfileId = 2},
                new StreamingCategory {Id = 3, Name = "Battle Royale", ProfileId = 3}
            );

            // Profiles: StreamerSponsors
            builder.Entity<StreamerSponsor>().ToTable("StreamerSponsors");
            builder.Entity<StreamerSponsor>().HasKey(ss => ss.Id);
            builder.Entity<StreamerSponsor>().Property(ss => ss.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<StreamerSponsor>().Property(ss => ss.Name).IsRequired();
            

            // Profiles: TournamentExperiences
            builder.Entity<TournamentExperience>().ToTable("TournamentExperiences");
            builder.Entity<TournamentExperience>().HasKey(te => te.Id);
            builder.Entity<TournamentExperience>().Property(te => te.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TournamentExperience>().Property(te => te.Name).IsRequired();
            builder.Entity<TournamentExperience>().Property(te => te.Position).IsRequired();
            builder.Entity<TournamentExperience>().Property(te => te.ProfileId).IsRequired();
            
            // Profiles: FavoriteGames
            builder.Entity<FavoriteGame>().ToTable("FavoriteGames");
            builder.Entity<FavoriteGame>().HasKey(fg => fg.Id);
            builder.Entity<FavoriteGame>().Property(fg => fg.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<FavoriteGame>().Property(fg => fg.GameName).IsRequired();
            builder.Entity<FavoriteGame>().Property(fg => fg.ProfileId).IsRequired();
            
            //Publications

            //Constraints
            builder.Entity<Publication>().ToTable("Publications");
            builder.Entity<Publication>().HasKey(p => p.Id);
            builder.Entity<Publication>().Property(p => p.Title).IsRequired();
            builder.Entity<Publication>().Property(p => p.Content).IsRequired();
            builder.Entity<Publication>().Property(p => p.PublicatedAt).IsRequired();
            builder.Entity<Publication>().Property(p => p.PublicationType).IsRequired();
            builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            
            //Users
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Premium).IsRequired();

            builder.UseSnakeCaseNamingConvention();

        }
    }
}