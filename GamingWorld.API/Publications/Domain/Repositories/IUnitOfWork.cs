using System.Threading.Tasks;

namespace GamingWorld.API.Publications.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}