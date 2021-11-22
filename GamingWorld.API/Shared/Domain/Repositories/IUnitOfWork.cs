using System.Threading.Tasks;

namespace GamingWorld.API.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}