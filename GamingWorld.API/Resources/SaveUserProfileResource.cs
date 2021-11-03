using System.ComponentModel.DataAnnotations;
using GamingWorld.API.Domain.Models;

namespace GamingWorld.API.Resources
{
    public class SaveUProfileResource
    {
        [Required]
        [Range(1, 3)]
        public int GamingLevel { get; set; }
        
        [Required]
        public bool IsStreamer { get; set; }
    }
}