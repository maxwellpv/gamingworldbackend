using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamingWorld.API.Users.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<Users.Domain.Models.User>> ListAsync();
        Task AddAsync(Users.Domain.Models.User user);
        Task<Users.Domain.Models.User> FindByIdAsync(int id);
        Task<Users.Domain.Models.User> FindByUsernameAsync(string username);
        void Update(Users.Domain.Models.User user);
        void Remove(Users.Domain.Models.User user);
        Task<Users.Domain.Models.User> FindByEmailAsync(string email);
    }
}