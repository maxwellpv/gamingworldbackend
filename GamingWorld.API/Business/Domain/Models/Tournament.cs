using System.Collections.Generic;
using GamingWorld.API.Profiles.Domain.Models;

namespace GamingWorld.API.Business.Domain.Models
{
    public class Tournament
    {
        public int Id { get; set; }

        //Relationships
        public int PublicationId { get; set; }
        
        public IEnumerable<Participant> Participants { get; set; }

    }
}