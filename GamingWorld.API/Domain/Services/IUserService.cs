using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Domain.Models;

namespace GamingWorld.API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
    }
}