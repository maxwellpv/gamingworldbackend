using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Business.Domain.Models;


namespace GamingWorld.API.Business.Domain.Repositories
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<Tournament>> ListAsync();

        Task AddAsync(Tournament tournament);

        Task<Tournament> FindByIdAsync(int id);

        Tournament FindById(int id);

        Task<Tournament> ListWithParticipantsById(int id);

        void Update(Tournament tournament);
        
        void Remove(Tournament tournament);
    }
}