namespace GamingWorld.API.Profiles.Domain.Models
{
    public class StreamerSponsor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relations
        public int ProfileId { get; set; }
    }
}