using System;
using System.Collections.Generic;
using System.Linq;
using GamingWorld.API.Profiles.Domain.Models;
using GamingWorld.API.Publications.Domain.Models;
using GamingWorld.API.Publications.Resources;

namespace GamingWorld.API.Business.Domain.Models
{
    public class Tournament
    {
        public int Id { get; set; }

        //Relationships

        public int ParticipantLimit { get; set; }
             
        public int PrizePool { get; set; }
        
        public string TournamentDate { get; set; }
        
        public Publication Publication { get; set; }
        public string TournamentHour { get; set; }
        public IEnumerable<Participant> Participants { get; set; }
        
        public bool TournamentStatus { get; set; }
        

    }
}