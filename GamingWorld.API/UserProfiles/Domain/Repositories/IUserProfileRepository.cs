using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.UserProfiles.Domain.Models;

namespace GamingWorld.API.UserProfiles.Domain.Repositories
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfile>> ListAsync();
        Task AddAsync(UserProfile userProfile);
        Task<UserProfile> FindByIdAsync (int id);
        Task<UserProfile> FindByUserId(int profileId);
        void Update(UserProfile userProfile);
        void Remove(UserProfile userProfile);
    }
}