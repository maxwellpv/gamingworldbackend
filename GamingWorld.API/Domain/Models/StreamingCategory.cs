namespace GamingWorld.API.Domain.Models
{
    public class StreamingCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        // public string ExternalId { get; set; }

        // Relations
        public int UserProfileId { get; set; }
        //public UserProfile UserProfile { get; set; }
    }
}