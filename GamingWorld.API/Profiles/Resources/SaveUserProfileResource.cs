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
        public int UserId { get; set; }
        
        [Required]
        public bool IsStreamer { get; set; }
        
        // Relations
        public IEnumerable<GameExperience> GameExperiences { get; set; }
        public IEnumerable<StreamingCategory> StreamingCategories { get; set; }
        public IEnumerable<StreamerSponsor> StreamerSponsors { get; set; }
        public IEnumerable<TournamentExperience> TournamentExperiences { get; set; }
        public IEnumerable<FavoriteGame> FavoriteGames { get; set; }
    }
}