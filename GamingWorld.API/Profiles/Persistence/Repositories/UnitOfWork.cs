using System.Threading.Tasks;
using GamingWorld.API.Profiles.Persistence.Context;

namespace GamingWorld.API.Profiles.Persistence.Repositories
{
    public class UnitOfWork : Users.Domain.Repositories.IUnitOfWork
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