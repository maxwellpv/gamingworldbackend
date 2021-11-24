namespace GamingWorld.API.Shared.Inbound.Games.Domain.Models
{
    public class TwitchOAuthResponse
    {
        // NOT FOLLOWING THE NAMING CONVENTION BECAUSE WE NEED TO MAP EXACT FIELD NAMES FROM OBJECT RESPONSE FROM TWITCH OAUTH.
        public string access_token { get; set; }

        public long expires_in { get; set; }

        public string token_type { get; set; }
    }
}