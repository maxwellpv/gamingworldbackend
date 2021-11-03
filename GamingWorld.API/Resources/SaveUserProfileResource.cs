using System.ComponentModel.DataAnnotations;
using GamingWorld.API.Domain.Models;

namespace GamingWorld.API.Resources
{
    public class SaveUserProfileResource
    {
        [Required]
        [Range(1, 3)]
        public int GamingLevel { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public bool IsStreamer { get; set; }
    }
}