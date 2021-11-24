using GamingWorld.API.Security.Domain.Models;

namespace GamingWorld.API.Business.Domain.Models
{
    public class Participant
    {
        public int Id { get; set; }

        //Relationships
        public int Points { get; set; }

        public int UserId { get; set; }
        
        public User User { get; set; }
        
        public int TournamentId { get; set; }
    }
}