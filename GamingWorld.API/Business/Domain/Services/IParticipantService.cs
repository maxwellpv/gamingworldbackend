using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Business.Domain.Models;
using GamingWorld.API.Business.Domain.Services.Communication;
using GamingWorld.API.Profiles.Domain.Services.Communication;

namespace GamingWorld.API.Business.Domain.Services
{
    public interface IParticipantService
    {
        Task<IEnumerable<Participant>> ListAsync();
        Task<Participant> ListByUserIdAsync(int userId);
        Task<ParticipantResponse> SaveAsync(Participant tournament);
        Task<ParticipantResponse> UpdateAsync(int id, Participant tournament);
        Task<ParticipantResponse> DeleteAsync(int id);
    }
}