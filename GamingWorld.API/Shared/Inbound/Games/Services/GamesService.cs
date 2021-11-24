using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using GamingWorld.API.Security.Exceptions;
using GamingWorld.API.Shared.Domain.Repositories;
using GamingWorld.API.Shared.Inbound.ExternalAPIs.Domain.Models;
using GamingWorld.API.Shared.Inbound.ExternalAPIs.Domain.Repositories;
using GamingWorld.API.Shared.Inbound.Games.Domain.Models;
using GamingWorld.API.Shared.Inbound.Games.Domain.Services;
using Microsoft.IdentityModel.Tokens;

namespace GamingWorld.API.Shared.Inbound.Games.Services
{
    public class GamesService : IGamesService
    {
        private readonly string TWITCH_OAUTH_URL = "https://id.twitch.tv/oauth2/token";
        private readonly string TWITCH_CLIENT_ID = "8en9cck6wbdrkinl4i0oahhxf3ali1";
        private readonly string TWITCH_CLIENT_SECRET = "jh7gihohaly38ds1e0v98xcnntn7wr";
        private readonly string TWITCH_GRANT_TYPE = "client_credentials";

        private readonly string IGDB_GAMES_ENDPOINT_URL = "https://api.igdb.com/v4/games";
        
        private readonly IExternalAPIRepository _externalApiRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GamesService(IExternalAPIRepository externalApiRepository, IUnitOfWork unitOfWork)
        {
            _externalApiRepository = externalApiRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Game>> ListRandomAsync(int limit)
        {
            var body = "fields name, cover.url; sort date desc; limit " + limit + ";";

            var response = await MakeIGDBRequest(body);

            return JsonSerializer.Deserialize<List<Game>>(response);
        }

        public async Task<Game> GetById(int id)
        {
            var body = "fields name, cover.url; where id=" + id + ";";

            var response = await MakeIGDBRequest(body);

            var responseObject = JsonSerializer.Deserialize<List<Game>>(response);

            if (responseObject == null)
                return null;

            return responseObject.Count > 0 ? responseObject[0] : null;
        }

        public async Task<IEnumerable<Game>> FindByName(string name, int limit)
        {
            if (name.IsNullOrEmpty())
                throw new AppException("Name must not be empty");
            
            var body = "fields name, cover.url; search \"" + name + "\"; limit " + limit + ";";

            var response = await MakeIGDBRequest(body);

            return JsonSerializer.Deserialize<List<Game>>(response);
        }

        public async Task<ExternalAPI> GetIGDBCredentials()
        {
            var externalAPI = await _externalApiRepository.FindByNameAsync("TWITCH_AUTH");

            if (externalAPI == null)
            {
                if (!await GetNewIGDBCredentials())
                    return null;
            }
            else if (DateTime.Now.ToFileTimeUtc() >= externalAPI.Expiration.ToFileTimeUtc())
            {
                if (!await GetNewIGDBCredentials())
                    return null;
            }
            
            return await _externalApiRepository.FindByNameAsync("TWITCH_AUTH");
        }

        public async Task<bool> GetNewIGDBCredentials()
        {
            
            //throw new Exception("HERE");
            using var client = new HttpClient();
            
            var data = new StringContent("", Encoding.UTF8, "application/json");
            
            var builder = new UriBuilder(TWITCH_OAUTH_URL);
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["client_id"] = TWITCH_CLIENT_ID;
            query["client_secret"] = TWITCH_CLIENT_SECRET;
            query["grant_type"] = TWITCH_GRANT_TYPE;
            builder.Query = query.ToString();
            
            string requestURL = builder.ToString();
            
            var response = await client.PostAsync(requestURL, data);

            var tokenResponse = JsonSerializer.Deserialize<TwitchOAuthResponse>(await response.Content.ReadAsStringAsync());

            if (tokenResponse == null || tokenResponse.access_token == null)
                return false;

            var externalAPI = new ExternalAPI();

            externalAPI.Name = "TWITCH_AUTH";
            externalAPI.Token = tokenResponse.access_token;
            externalAPI.Expiration = DateTime.Now.AddSeconds(tokenResponse.expires_in).AddDays(-1);

            await _externalApiRepository.AddAsync(externalAPI);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<string> MakeIGDBRequest(string content)
        {
            ExternalAPI credentials = await GetIGDBCredentials();
            
            if (credentials.Token.IsNullOrEmpty())
                throw new AppException("Internal token error.");
            
            using var client = new HttpClient();

            var data = new StringContent(content, Encoding.UTF8, "application/json");
            
            client.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue("Bearer", credentials.Token);
            client.DefaultRequestHeaders.Add("Client-ID", TWITCH_CLIENT_ID);
            
            var response = await client.PostAsync(IGDB_GAMES_ENDPOINT_URL, data);

            return await response.Content.ReadAsStringAsync();
        }
    }
}