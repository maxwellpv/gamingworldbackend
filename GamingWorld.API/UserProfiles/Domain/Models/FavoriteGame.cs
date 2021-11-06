namespace GamingWorld.API.UserProfiles.Domain.Models
{
    public class FavoriteGame
    {
        public int Id { get; set; }
        public string GameName { get; set; }

        // Relations
        public int UserProfileId { get; set; }
        //public UserProfile UserProfile { get; set; }
    }
}