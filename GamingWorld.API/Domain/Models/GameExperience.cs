using System.ComponentModel.DataAnnotations.Schema;

namespace GamingWorld.API.Domain.Models
{
    public class GameExperience
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public int Time { get; set; }
        public EGameExperienceTime TimeUnit { get; set; }
        
        // Relations
        public int UserProfileId { get; set; }
        //public UserProfile UserProfile { get; set; }
    }
}