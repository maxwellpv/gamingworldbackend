using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Domain.Models;

namespace GamingWorld.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindByIdAsync(int id);
        Task<User> FindByUsernameAsync(string username);
        void Update(User user);
        void Remove(User user);
        Task<User> FindByEmailAsync(string email);
    }
}