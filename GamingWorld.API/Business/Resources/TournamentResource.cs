using System.Collections.Generic;
using GamingWorld.API.Business.Domain.Models;
using GamingWorld.API.Profiles.Domain.Models;

namespace GamingWorld.API.Business.Resources
{
    public class TournamentResource
    {
        public int Id { get; set; }

        //Relationships
        public int PublicationId { get; set; }
        
        public IEnumerable<Participant> Participants { get; set; }
    }
}