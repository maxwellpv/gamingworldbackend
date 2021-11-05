using System.Threading.Tasks;

namespace GamingWorld.API.UserProfiles.Domain.Repositories
{
    public partial interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}