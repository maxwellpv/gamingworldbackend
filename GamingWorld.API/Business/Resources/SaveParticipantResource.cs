using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GamingWorld.API.Profiles.Domain.Models;

namespace GamingWorld.API.Business.Resources
{
    public class SaveParticipantResource
    {

        [Required]
        public int UserId { get; set; }
        
        [Required]
        public int TournamentId { get; set; }
        
        public int Points { get; set; }


        
    }
}