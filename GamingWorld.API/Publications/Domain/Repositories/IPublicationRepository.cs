using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Publications.Domain.Models;

namespace GamingWorld.API.Publications.Domain.Repositories
{
    public interface IPublicationRepository
    {
        Task<IEnumerable<Publication>> ListAsync();
        
        Task<IEnumerable<Publication>> ListByTypeAsync();
        
        Task AddAsync(Publication publication);

        Task<Publication> FindByIdAsync(int id);

        void Update(Publication publication);
        
        void Remove(Publication publication);
    }
}