using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Users.Domain.Services.Communication;

namespace GamingWorld.API.Users.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<Users.Domain.Models.User>> ListAsync();
        Task<Users.Domain.Models.User> ListByUserIdAsync(int userId);
        Task<Users.Domain.Models.User> ListByUserUsernameAsync(int username);
        Task<UserResponse> SaveAsync(Users.Domain.Models.User user);
        Task<UserResponse> UpdateAsync(int id, Users.Domain.Models.User user);
        Task<UserResponse> DeleteAsync(int id);
    }
}