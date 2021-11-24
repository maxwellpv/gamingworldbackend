using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Profiles.Domain.Models;
using GamingWorld.API.Profiles.Domain.Services.Communication;

namespace GamingWorld.API.Profiles.Domain.Services
{
    public interface IUProfileService
    {
        Task<IEnumerable<Profile>> ListAsync();
        Task<Profile> ListByUserIdAsync(int userId);
        Task<Profile> ListByIdAsync(int id);
        Task<ProfileResponse> SaveAsync(Profile profile);
        Task<ProfileResponse> UpdateAsync(int id, Profile profile);
        Task<ProfileResponse> DeleteAsync(int id);
    }
}