
namespace GamingWorld.API.Resources
{
    public class UserProfileResource
    {
        public int Id { get; set;  }
        public int UserId { get; set;  }
        public string GamingLevel { get; set; }
        
        public bool IsStreamer { get; set; }
    }
}