using System.Threading.Tasks;
using GamingWorld.API.Shared.Inbound.ExternalAPIs.Domain.Models;

namespace GamingWorld.API.Shared.Inbound.ExternalAPIs.Domain.Repositories
{
    public interface IExternalAPIRepository
    {
        Task AddAsync(ExternalAPI externalApi);
        Task<ExternalAPI> FindByNameAsync(string name);
        void Update(ExternalAPI externalApi);
        void Remove(ExternalAPI externalApi);
    }
}