namespace GamingWorld.API.Shared.Inbound.Games.Domain.Models
{
    public class GameCover
    {
        // NOT FOLLOWING THE NAMING CONVENTION BECAUSE WE NEED TO MAP EXACT FIELD NAMES FROM OBJECT RESPONSE FROM IGDB.
        
        public int id { get; set; }
        
        public string url { get; set; }
    }
}