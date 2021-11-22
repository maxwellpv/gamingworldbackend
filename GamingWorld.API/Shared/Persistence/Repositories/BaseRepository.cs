using GamingWorld.API.Shared.Persistence.Contexts;

namespace GamingWorld.API.Shared.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}