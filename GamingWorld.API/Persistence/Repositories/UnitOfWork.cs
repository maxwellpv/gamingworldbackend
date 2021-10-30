using System.Threading.Tasks;
using GamingWorld.API.Domain.Repositories;
using GamingWorld.API.Persistence.Contexts;

namespace GamingWorld.API.Persistence.Repositories
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