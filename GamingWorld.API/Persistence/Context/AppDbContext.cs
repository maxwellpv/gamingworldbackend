﻿using System.Collections.Generic;
using GamingWorld.API.Domain.Models;
using GamingWorld.API.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GamingWorld.API.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // EXAMPLE
            GameExperience exampleExperience = new GameExperience();
            exampleExperience.Id = 1;
            exampleExperience.Time = 5;
            exampleExperience.GameName = "Among You";
            exampleExperience.TimeUnit = EGameExperienceTime.M;
            exampleExperience.UserProfileId = 1;
            // EXAMPLE
            
            //Users
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
            

            builder.Entity<GameExperience>().ToTable("GameExperiences");
            builder.Entity<GameExperience>().HasKey(ge => ge.Id);
            builder.Entity<GameExperience>().Property(ge => ge.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<GameExperience>().Property(ge => ge.GameName).IsRequired();
            builder.Entity<GameExperience>().Property(ge => ge.Time).IsRequired();
            builder.Entity<GameExperience>().Property(ge => ge.TimeUnit).IsRequired();
            builder.Entity<GameExperience>().HasOne(ge => ge.UserProfile).WithMany(p => p.GameExperiences)
                .HasForeignKey("UserProfileId").OnDelete(DeleteBehavior.Cascade);

            builder.Entity<GameExperience>().HasData
            (
                new GameExperience{Id = 1, GameName = "Among Us", Time = 5, TimeUnit = EGameExperienceTime.M, UserProfileId = 1},
                new GameExperience{Id = 2, GameName = "Call of Duty", Time = 4, TimeUnit = EGameExperienceTime.Y, UserProfileId = 2},
                new GameExperience{Id = 3, GameName = "Manco's Combat", Time = 25, TimeUnit = EGameExperienceTime.D, UserProfileId = 3}
            );

            //Profiles
            builder.Entity<UserProfile>().ToTable("Profiles");
            builder.Entity<UserProfile>().HasKey(p => p.Id);
            builder.Entity<UserProfile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserProfile>().Property(p => p.UserId).IsRequired();
            builder.Entity<UserProfile>().Property(p => p.GamingLevel).IsRequired();
            builder.Entity<UserProfile>().Property(p => p.IsStreamer).IsRequired();
            builder.Entity<UserProfile>().HasMany(p => p.GameExperiences).WithOne();

            builder.Entity<UserProfile>().HasData
            (
                new UserProfile{Id = 1, UserId = 1, GamingLevel = EGamingLevel.A, IsStreamer = true},
                new UserProfile{Id = 2, UserId = 2, GamingLevel = EGamingLevel.N, IsStreamer = true},
                new UserProfile{Id = 3, UserId = 3, GamingLevel = EGamingLevel.M, IsStreamer = false},
                new UserProfile{Id = 4, UserId = 4, GamingLevel = EGamingLevel.A, IsStreamer = false}
            );

            builder.UseSnakeCaseNamingConvention();

        }
    }
}