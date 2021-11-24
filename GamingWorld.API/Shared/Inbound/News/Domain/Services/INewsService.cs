using System;
using System.Threading.Tasks;

namespace GamingWorld.API.Shared.Inbound.News.Domain.Services
{
    public interface INewsService
    {
        Task<String> ListByTheme(string theme);
    }
}