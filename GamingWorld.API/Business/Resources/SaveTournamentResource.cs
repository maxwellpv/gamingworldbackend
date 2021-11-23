using System.ComponentModel.DataAnnotations;

namespace GamingWorld.API.Business.Resources
{
    public class SaveTournamentResource
    {
        
        //Relationships
        [Required]
        public int PublicationId { get; set; }

    }
}

