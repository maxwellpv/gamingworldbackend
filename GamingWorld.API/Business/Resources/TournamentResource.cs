using System;
using System.Collections.Generic;
using GamingWorld.API.Business.Domain.Models;
using GamingWorld.API.Profiles.Domain.Models;
using GamingWorld.API.Publications.Domain.Models;
using GamingWorld.API.Publications.Resources;

namespace GamingWorld.API.Business.Resources
{
    public class TournamentResource
    {
        public int Id { get; set; }
        
        public int ParticipantLimit { get; set; }
             
        public int PrizePool { get; set; }
        
        public string TournamentDate { get; set; }
             
        public string TournamentHour { get; set; }
        
        public int PublicationId { get; set; }
        
        public bool TournamentStatus { get; set; }

        //Relationships

        public IEnumerable<Participant> Participants { get; set; }
    }
}