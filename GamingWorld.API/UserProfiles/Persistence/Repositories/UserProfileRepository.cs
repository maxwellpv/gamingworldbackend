using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.UserProfiles.Domain.Models;
using GamingWorld.API.UserProfiles.Domain.Repositories;
using GamingWorld.API.UserProfiles.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GamingWorld.API.UserProfiles.Persistence.Repositories
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserProfile>> ListAsync()
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

        public async Task AddAsync(UserProfile userProfile)
        {
            await _context.Profiles.AddAsync(userProfile);
        }

        public async Task<UserProfile> FindByIdAsync(int id)
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

        public async Task<UserProfile> FindByUserId(int userId)
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

        public void Update(UserProfile userProfile)
        {
            _context.Profiles.Update(userProfile);
        }

        public void Remove(UserProfile userProfile)
        {
            _context.Profiles.Remove(userProfile);
        }
    }
}