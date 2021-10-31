using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Domain.Models;

namespace GamingWorld.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
    }
}