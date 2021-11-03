using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Domain.Models;
using GamingWorld.API.Domain.Repositories;
using GamingWorld.API.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GamingWorld.API.Persistence.Repositories
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserProfile>> ListAsync()
        {
            return await _context.Profiles.ToListAsync();
        }

        public async Task AddAsync(UserProfile userProfile)
        {
            await _context.Profiles.AddAsync(userProfile);
        }

        public async Task<UserProfile> FindByIdAsync(int id)
        {
            return await _context.Profiles.FindAsync(id);
        }

        public async Task<UserProfile> FindByUserId(int userId)
        {
            return await _context.Profiles.FindAsync(userId);
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