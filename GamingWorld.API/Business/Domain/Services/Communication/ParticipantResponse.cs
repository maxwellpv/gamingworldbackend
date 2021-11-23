using GamingWorld.API.Business.Domain.Models;
using GamingWorld.API.Shared.Domain.Services.Communication;

namespace GamingWorld.API.Business.Domain.Services.Communication
{
    public class ParticipantResponse : BaseResponse<Participant>
        {
            public ParticipantResponse(string message) : base(message)
            {
            }

            public ParticipantResponse(Participant participant) : base(participant)
            {
            }
        }
    
}