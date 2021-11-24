using System.Collections.Generic;
using GamingWorld.API.Profiles.Domain.Models;
using GamingWorld.API.Security.Resources;

namespace GamingWorld.API.Business.Resources
{
    public class ParticipantResource
    {
        public int Id { get; set;  }
        public UserResource User { get; set;  }
        public int TournamentId { get; set; }
        public int Points { get; set; }

    }
}