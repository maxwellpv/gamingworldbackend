using System.Threading.Tasks;

namespace GamingWorld.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}