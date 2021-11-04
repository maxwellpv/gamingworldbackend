
using System.Collections;
using System.Collections.Generic;
using GamingWorld.API.Domain.Models;

namespace GamingWorld.API.Resources
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
    }
}