namespace GamingWorld.API.Profiles.Domain.Models
{
    public class FavoriteGame
    {
        public int Id { get; set; }
        public string GameName { get; set; }

        // Relations
        public int ProfileId { get; set; }
        //public Profile Profile { get; set; }
    }
}