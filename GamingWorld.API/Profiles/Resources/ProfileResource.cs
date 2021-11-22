using System.Collections.Generic;
using GamingWorld.API.Profiles.Domain.Models;
using GamingWorld.API.Security.Resources;

namespace GamingWorld.API.Profiles.Resources
{
    public class ProfileResource
    {
        public int Id { get; set;  }
        public UserResource User { get; set;  }
        public string GamingLevel { get; set; }
        
        public bool IsStreamer { get; set; }
        
        // Relations
        public IEnumerable<GameExperience> GameExperiences { get; set; }
        public IEnumerable<StreamingCategory> StreamingCategories { get; set; }
        public IEnumerable<StreamerSponsor> StreamerSponsors { get; set; }
        public IEnumerable<TournamentExperience> TournamentExperiences { get; set; }
        public IEnumerable<FavoriteGame> FavoriteGames { get; set; }
    }
}