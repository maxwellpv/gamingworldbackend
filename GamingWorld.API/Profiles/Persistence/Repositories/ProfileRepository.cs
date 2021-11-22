using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Profiles.Domain.Models;
using GamingWorld.API.Profiles.Domain.Repositories;
using GamingWorld.API.Shared.Persistence.Contexts;
using GamingWorld.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GamingWorld.API.Profiles.Persistence.Repositories
{
    public class ProfileRepository : BaseRepository, IProfileRepository
    {
        public ProfileRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Profile>> ListAsync()
        {
            // return await _context.Profiles.Include(up => up.User).ToListAsync(); // Pending to check if we really need the full user info when retrieving profiles.
            return await _context.Profiles
                .Include(up => up.GameExperiences)
                .Include(up => up.StreamingCategories)
                .Include(up => up.StreamerSponsors)
                .Include(up => up.TournamentExperiences)
                .Include(up => up.FavoriteGames)
                .ToListAsync();
        }

        public async Task AddAsync(Profile profile)
        {
            await _context.Profiles.AddAsync(profile);
        }

        public async Task<Profile> FindByIdAsync(int id)
        {
            // return await _context.Profiles.Include(up => up.User).FirstOrDefaultAsync(up => up.Id == id); // Pending to check if we really need the full user info when retrieving profiles.
            return await _context.Profiles
                .Include(up => up.GameExperiences)
                .Include(up => up.StreamingCategories)
                .Include(up => up.StreamerSponsors)
                .Include(up => up.TournamentExperiences)
                .Include(up => up.FavoriteGames)
                .FirstOrDefaultAsync(up => up.Id == id);
        }

        public async Task<Profile> FindByUserId(int userId)
        {
            //return await _context.Profiles.Include(up => up.User).FirstOrDefaultAsync(up => up.UserId == userId); // Pending to check if we really need the full user info when retrieving profiles.
            return await _context.Profiles
                .Include(up => up.GameExperiences)
                .Include(up => up.StreamingCategories)
                .Include(up => up.StreamerSponsors)
                .Include(up => up.TournamentExperiences)
                .Include(up => up.FavoriteGames)
                .FirstOrDefaultAsync(up => up.UserId == userId);
        }

        public void Update(Profile profile)
        {
            _context.Profiles.Update(profile);
        }

        public void Remove(Profile profile)
        {
            _context.Profiles.Remove(profile);
        }
    }
}