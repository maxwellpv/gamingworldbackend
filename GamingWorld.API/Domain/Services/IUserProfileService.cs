using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Domain.Models;
using GamingWorld.API.Domain.Services.Communication;

namespace GamingWorld.API.Domain.Services
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