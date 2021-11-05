using System.Threading.Tasks;
using GamingWorld.API.UserProfiles.Persistence.Context;

namespace GamingWorld.API.Users.Persistence.Repositories
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