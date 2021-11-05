namespace GamingWorld.API.UserProfiles.Domain.Models
{
    public class StreamerSponsor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relations
        public int UserProfileId { get; set; }
    }
}