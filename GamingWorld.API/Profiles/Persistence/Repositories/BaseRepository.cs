using GamingWorld.API.Profiles.Persistence.Context;

namespace GamingWorld.API.Profiles.Persistence.Repositories
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