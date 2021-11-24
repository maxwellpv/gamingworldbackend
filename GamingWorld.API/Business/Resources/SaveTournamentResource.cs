using System.ComponentModel.DataAnnotations;

namespace GamingWorld.API.Business.Resources
{
    public class SaveTournamentResource
    {
        
        //Relationships
        [Required]
        public int PublicationId { get; set; }
        
        [Required]
        public int ParticipantLimit { get; set; }
        
        [Required]
        public int PrizePool { get; set; }
        
        [Required]
        public string TournamentDate { get; set; }
        
        [Required]
        public string TournamentHour { get; set; }

    }
}

