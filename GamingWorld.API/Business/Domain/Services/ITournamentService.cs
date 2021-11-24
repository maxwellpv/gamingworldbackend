using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Business.Domain.Models;
using GamingWorld.API.Business.Domain.Services.Communication;
using GamingWorld.API.Profiles.Domain.Services.Communication;

namespace GamingWorld.API.Business.Domain.Services
{
    public interface ITournamentService
    {
        Task<Tournament> GetById(int id);
        Task<IEnumerable<Tournament>> ListAsync();
        Task<Tournament> ListByUserIdAsync(int userId);
        Task<Tournament> ListWithParticipantsByIdAsync(int tournamentId);
        Task<TournamentResponse> SaveAsync(Tournament tournament);
        Task<TournamentResponse> UpdateAsync(int id, Tournament tournament);
        Task<TournamentResponse> DeleteAsync(int id);
        Task<ParticipantResponse> UpdateParticipantPoints(int tournamentId, int participantId, int points);
        
    }
}