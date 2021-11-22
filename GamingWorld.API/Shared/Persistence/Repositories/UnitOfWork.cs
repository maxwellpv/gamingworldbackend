using System.Threading.Tasks;
using GamingWorld.API.Shared.Domain.Repositories;
using GamingWorld.API.Shared.Persistence.Contexts;

namespace GamingWorld.API.Shared.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}