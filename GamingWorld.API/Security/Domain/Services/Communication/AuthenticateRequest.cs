using System.ComponentModel.DataAnnotations;

namespace GamingWorld.API.Security.Domain.Services.Communication
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}