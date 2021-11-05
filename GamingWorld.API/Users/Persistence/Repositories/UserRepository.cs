using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.UserProfiles.Persistence.Context;
using GamingWorld.API.Users.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GamingWorld.API.Users.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Users.Domain.Models.User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }
        
        public async Task AddAsync(Users.Domain.Models.User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<Users.Domain.Models.User> FindByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Users.Domain.Models.User> FindByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Username == username);
        }

        public async Task<Users.Domain.Models.User> FindByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Email == email);
        }
        
        public void Update(Users.Domain.Models.User user)
        {
            _context.Users.Update(user);
        }

        public void Remove(Users.Domain.Models.User user)
        {
            _context.Users.Remove(user);
        }
    }
}