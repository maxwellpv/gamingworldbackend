using System.Threading.Tasks;

namespace GamingWorld.API.Profiles.Domain.Repositories
{
    public partial interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}