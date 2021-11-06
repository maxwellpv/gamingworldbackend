using GamingWorld.API.UserProfiles.Persistence.Context;

namespace GamingWorld.API.UserProfiles.Persistence.Repositories
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