using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Profiles.Domain.Models;

namespace GamingWorld.API.Profiles.Domain.Repositories
{
    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>> ListAsync();
        Task AddAsync(Profile profile);
        Task<Profile> FindByIdAsync (int id);
        Task<Profile> FindByUserId(int profileId);
        void Update(Profile profile);
        void Remove(Profile profile);
    }
}