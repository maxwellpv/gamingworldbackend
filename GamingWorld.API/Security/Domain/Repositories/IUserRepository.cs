using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Security.Domain.Models;

namespace GamingWorld.API.Security.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindByIdAsync(int id);
        Task<User> FindByUsernameAsync(string username);
        bool ExistsByUserName(string username);
        void Update(User user);
        void Remove(User user);
        Task<User> FindByEmailAsync(string email);
    }
}