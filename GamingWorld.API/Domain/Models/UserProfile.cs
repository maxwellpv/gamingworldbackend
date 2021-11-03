using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingWorld.API.Domain.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public EGamingLevel GamingLevel { get; set; }
        public bool IsStreamer { get; set; }
        
        public User User { get; set; }
        public IList<GameExperience> GameExperiences { get; set; }
        
    }
}