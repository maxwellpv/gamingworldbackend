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

            builder.Entity<Profile>().HasData
            (
                new Profile {Id = 1, UserId = 1, GamingLevel = EGamingLevel.A, IsStreamer = true},
                new Profile {Id = 2, UserId = 2, GamingLevel = EGamingLevel.N, IsStreamer = true},
                new Profile {Id = 3, UserId = 3, GamingLevel = EGamingLevel.M, IsStreamer = false},
                new Profile {Id = 4, UserId = 4, GamingLevel = EGamingLevel.A, IsStreamer = false}
            );

            // Profiles: GameExperiences
            builder.Entity<GameExperience>().ToTable("GameExperiences");
            builder.Entity<GameExperience>().HasKey(ge => ge.Id);
            builder.Entity<GameExperience>().Property(ge => ge.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<GameExperience>().Property(ge => ge.GameName).IsRequired();
            builder.Entity<GameExperience>().Property(ge => ge.Time).IsRequired();
            builder.Entity<GameExperience>().Property(ge => ge.TimeUnit).IsRequired();
            builder.Entity<GameExperience>().HasData
            (
                new GameExperience
                    {Id = 1, GameName = "Among Us", Time = 5, TimeUnit = EGameExperienceTime.M, ProfileId = 1},
                new GameExperience
                    {Id = 2, GameName = "Call of Duty", Time = 4, TimeUnit = EGameExperienceTime.Y, ProfileId = 2},
                new GameExperience
                    {Id = 3, GameName = "Manco's Combat", Time = 25, TimeUnit = EGameExperienceTime.D, ProfileId = 3}
            );

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

            builder.Entity<StreamerSponsor>().HasData
            (
                new StreamerSponsor {Id = 1, Name = "Coca Cola", ProfileId = 1},
                new StreamerSponsor {Id = 2, Name = "Pepsi", ProfileId = 2},
                new StreamerSponsor {Id = 3, Name = "Fanta", ProfileId = 3}
            );

            // Profiles: TournamentExperiences
            builder.Entity<TournamentExperience>().ToTable("TournamentExperiences");
            builder.Entity<TournamentExperience>().HasKey(te => te.Id);
            builder.Entity<TournamentExperience>().Property(te => te.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TournamentExperience>().Property(te => te.Name).IsRequired();
            builder.Entity<TournamentExperience>().Property(te => te.Position).IsRequired();
            builder.Entity<TournamentExperience>().Property(te => te.ProfileId).IsRequired();

            builder.Entity<TournamentExperience>().HasData
            (
                new TournamentExperience {Id = 1, Name = "Noobs Tournament", Position = 23, ProfileId = 1},
                new TournamentExperience {Id = 2, Name = "PUBG Championship", Position = 1, ProfileId = 2},
                new TournamentExperience {Id = 3, Name = "CODM Championship", Position = 7, ProfileId = 3}
            );

            // Profiles: FavoriteGames
            builder.Entity<FavoriteGame>().ToTable("FavoriteGames");
            builder.Entity<FavoriteGame>().HasKey(fg => fg.Id);
            builder.Entity<FavoriteGame>().Property(fg => fg.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<FavoriteGame>().Property(fg => fg.GameName).IsRequired();
            builder.Entity<FavoriteGame>().Property(fg => fg.ProfileId).IsRequired();

            builder.Entity<FavoriteGame>().HasData
            (
                new FavoriteGame {Id = 1, GameName = "Among Us", ProfileId = 1},
                new FavoriteGame {Id = 2, GameName = "Call of Duty", ProfileId = 2},
                new FavoriteGame {Id = 3, GameName = "Free Fire", ProfileId = 3}
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