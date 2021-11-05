using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.UserProfiles.Domain.Models;
using GamingWorld.API.UserProfiles.Domain.Services.Communication;

namespace GamingWorld.API.UserProfiles.Domain.Services
{
    public interface IUProfileService
    {
        Task<IEnumerable<UserProfile>> ListAsync();
        Task<UserProfile> ListByUserIdAsync(int userId);
        Task<UserProfileResponse> SaveAsync(UserProfile userProfile);
        Task<UserProfileResponse> UpdateAsync(int id, UserProfile userProfile);
        Task<UserProfileResponse> DeleteAsync(int id);
    }
}