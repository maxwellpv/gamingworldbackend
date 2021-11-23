using System;

namespace GamingWorld.API.Shared.Inbound.ExternalAPIs.Domain.Models
{
    public class ExternalAPI
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Token { get; set; }
        
        public DateTime Expiration { get; set; }
    }
}