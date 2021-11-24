using GamingWorld.API.Business.Domain.Models;
using GamingWorld.API.Shared.Domain.Services.Communication;

namespace GamingWorld.API.Business.Domain.Services.Communication
{
    public class TournamentResponse : BaseResponse<Tournament>
        {
            public TournamentResponse(string message) : base(message)
            {
            }

            public TournamentResponse(Tournament tournament) : base(tournament)
            {
            }
        }
    
}