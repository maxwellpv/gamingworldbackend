using System.ComponentModel.DataAnnotations;

namespace GamingWorld.API.Security.Resources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(50)]
        public string Username  { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        
        [Required]
        public bool Premium { get; set; }
    }
}