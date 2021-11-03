using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Domain.Models;

namespace GamingWorld.API.Domain.Repositories
{
    public interface IUProfileRepository
    {
        Task<IEnumerable<UserProfile>> ListAsync();
        Task AddAsync(UserProfile userProfile);
        Task<UserProfile> FindByIdAsync (int id);
        Task<UserProfile> FindByUserId(int profileId);
        void Update(UserProfile userProfile);
        void Remove(UserProfile userProfile);
    }
}