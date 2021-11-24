using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GamingWorld.API.Profiles.Domain.Models;

namespace GamingWorld.API.Profiles.Resources
{
    public class SaveProfileResource
    {
        [Required]
        [Range(1, 3)]
        public int GamingLevel { get; set; }

        [Required]
        public bool IsStreamer { get; set; }
        
        // Relations
        public IEnumerable<GameExperience> GameExperiences { get; set; } = new List<GameExperience>();
        public IEnumerable<StreamingCategory> StreamingCategories { get; set; } = new List<StreamingCategory>();
        public IEnumerable<StreamerSponsor> StreamerSponsors { get; set; } = new List<StreamerSponsor>();
        public IEnumerable<TournamentExperience> TournamentExperiences { get; set; } = new List<TournamentExperience>();
        public IEnumerable<FavoriteGame> FavoriteGames { get; set; } = new List<FavoriteGame>();
    }
}