using System.Collections.Generic;
using GamingWorld.API.Profiles.Domain.Models;
using GamingWorld.API.Security.Domain.Models;
using GamingWorld.API.Security.Resources;

namespace GamingWorld.API.Profiles.Resources
{
    public class ProfileResource
    {
        public int Id { get; set;  }
        public int UserId { get; set;  }
        public string GamingLevel { get; set; }
        
        public bool IsStreamer { get; set; }
        
        // Relations
        public IEnumerable<GameExperience> GameExperiences { get; set; } = new List<GameExperience>();
        public IEnumerable<StreamingCategory> StreamingCategories { get; set; } = new List<StreamingCategory>();
        public IEnumerable<StreamerSponsor> StreamerSponsors { get; set; } = new List<StreamerSponsor>();
        public IEnumerable<TournamentExperience> TournamentExperiences { get; set; } = new List<TournamentExperience>();
        public IEnumerable<FavoriteGame> FavoriteGames { get; set; } = new List<FavoriteGame>();
    }
}