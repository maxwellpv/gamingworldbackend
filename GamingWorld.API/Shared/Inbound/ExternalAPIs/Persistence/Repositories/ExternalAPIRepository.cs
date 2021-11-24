using System.Linq;
using System.Threading.Tasks;
using GamingWorld.API.Shared.Inbound.ExternalAPIs.Domain.Models;
using GamingWorld.API.Shared.Inbound.ExternalAPIs.Domain.Repositories;
using GamingWorld.API.Shared.Persistence.Contexts;
using GamingWorld.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GamingWorld.API.Shared.Inbound.ExternalAPIs.Persistence.Repositories
{
    public class ExternalAPIRepository : BaseRepository, IExternalAPIRepository
    {
        public ExternalAPIRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task AddAsync(ExternalAPI externalApi)
        {
            await _context.ExternalApis.AddAsync(externalApi);
        }

        public async Task<ExternalAPI> FindByNameAsync(string name)
        {
            return await _context.ExternalApis.OrderByDescending(api => api.Expiration).FirstOrDefaultAsync(api => api.Name == name);
        }

        public void Update(ExternalAPI externalApi)
        {
            _context.Update(externalApi);
        }

        public void Remove(ExternalAPI externalApi)
        {
            _context.Remove(externalApi);
        }
    }
}