using System.Threading.Tasks;

namespace GamingWorld.API.Users.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}