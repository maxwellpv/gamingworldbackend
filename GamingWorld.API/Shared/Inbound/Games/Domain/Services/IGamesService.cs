using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Shared.Inbound.ExternalAPIs.Domain.Models;
using GamingWorld.API.Shared.Inbound.Games.Domain.Models;

namespace GamingWorld.API.Shared.Inbound.Games.Domain.Services
{
    public interface IGamesService
    {
        Task<IEnumerable<Game>> ListRandomAsync(int limit);
        Task<Game> GetById(int id);
        Task<IEnumerable<Game>> FindByName(string name, int limit);
        Task<string> FindTopGames(int limit);
        Task<ExternalAPI> GetIGDBCredentials();

        Task<bool> GetNewIGDBCredentials();

        Task<string> MakeIGDBRequest(string content);
    }
}