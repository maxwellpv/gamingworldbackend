using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Publications.Domain.Models;
using GamingWorld.API.Publications.Domain.Services.Communication;
using GamingWorld.API.Publications.Resources;

namespace GamingWorld.API.Publications.Domain.Services
{
    public interface IPublicationService
    {
        Task<IEnumerable<Publication>> ListAsync();
        
        Task<IEnumerable<Publication>> ListByTypeAsync(int type);
        
        Task<Publication> GetById(int id);

        Task<PublicationResponse> SaveAsync(SavePublicationResource publication);

        Task<PublicationResponse> UpdateAsync(int id, Publication publication);

        Task<PublicationResponse> DeleteAsync(int id);
    }
}