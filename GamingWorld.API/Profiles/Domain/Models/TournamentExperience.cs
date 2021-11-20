namespace GamingWorld.API.Profiles.Domain.Models
{
    public class TournamentExperience
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        
        // Relations
        public int ProfileId { get; set; }
    }
}