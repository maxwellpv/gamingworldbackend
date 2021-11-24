using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Business.Domain.Models;


namespace GamingWorld.API.Business.Domain.Repositories
{
    public interface IParticipantRepository
    {
        Task<IEnumerable<Participant>> ListAsync();

        Task AddAsync(Participant participant);

        Task<Participant> FindByIdAsync(int id);

        void Update(Participant participant);
        Participant FindById(int id);
        void Remove(Participant participant);
    }
}