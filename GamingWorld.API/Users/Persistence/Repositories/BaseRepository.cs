using GamingWorld.API.UserProfiles.Persistence.Context;

namespace GamingWorld.API.Users.Persistence.Repositories
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