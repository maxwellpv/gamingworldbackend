using System.Collections.Generic;
using GamingWorld.API.UserProfiles.Domain.Models;
using GamingWorld.API.Users.Resources;

namespace GamingWorld.API.UserProfiles.Resources
{
    public class UserProfileResource
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