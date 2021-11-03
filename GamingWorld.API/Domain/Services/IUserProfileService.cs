using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Domain.Models;
using GamingWorld.API.Services.Communication;

namespace GamingWorld.API.Domain.Services
{
    public interface IUProfileService
    {
        Task<IEnumerable<UserProfile>> ListAsync();
        Task<UserProfile> ListByUserIdAsync(int userId);
        Task<UProfileResponse> SaveAsync(UserProfile userProfile);
        Task<UProfileResponse> UpdateAsync(int id, UserProfile userProfile);
        Task<UProfileResponse> DeleteAsync(int id);
    }
}