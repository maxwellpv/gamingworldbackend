namespace GamingWorld.API.Profiles.Domain.Models
{
    public class GameExperience
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public int Time { get; set; }
        public EGameExperienceTime TimeUnit { get; set; }
        
        // Relations
        public int ProfileId { get; set; }
        //public Profile Profile { get; set; }
    }
}