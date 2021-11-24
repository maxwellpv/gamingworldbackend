namespace GamingWorld.API.Profiles.Domain.Models
{
    public class StreamingCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        // public string ExternalId { get; set; }

        // Relations
        public int ProfileId { get; set; }
        //public Profile Profile { get; set; }
    }
}