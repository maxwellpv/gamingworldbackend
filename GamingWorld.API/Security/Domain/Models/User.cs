using System.Text.Json.Serialization;

namespace GamingWorld.API.Security.Domain.Models
{
    public class User
    {
      public int Id { get; set; }
      public string Username { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Email { get; set; }
      public bool Premium { get; set; }
      
      [JsonIgnore]
      public string PasswordHash { get; set; }
   
    }
}