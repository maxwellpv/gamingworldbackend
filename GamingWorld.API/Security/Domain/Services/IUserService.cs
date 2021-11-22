using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Security.Domain.Models;
using GamingWorld.API.Security.Domain.Services.Communication;

namespace GamingWorld.API.Security.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<User> GetByIdAsync(int userId);
        Task<User> ListByUserUsernameAsync(int username);
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);
    }
}