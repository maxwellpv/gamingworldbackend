using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Domain.Models;
using GamingWorld.API.Domain.Services.Communication;

namespace GamingWorld.API.Domain.Services
{
    public interface IPublicationService
    {
        Task<IEnumerable<Publication>> ListAsync();
        
        Task<IEnumerable<Publication>> ListByTypeAsync(int type);

        Task<PublicationResponse> SaveAsync(Publication publication);

        Task<PublicationResponse> UpdateAsync(int id, Publication publication);

        Task<PublicationResponse> DeleteAsync(int id);
    }
}