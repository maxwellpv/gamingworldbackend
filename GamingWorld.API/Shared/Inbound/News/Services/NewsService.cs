using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using GamingWorld.API.Security.Exceptions;
using GamingWorld.API.Shared.Inbound.News.Domain.Services;

namespace GamingWorld.API.Shared.Inbound.News.Services
{
    public class NewsService: INewsService
    {
        private readonly string NEWS_URL = "https://newsapi.org/v2/everything";
        
        public async Task<string> ListByTheme(string theme)
        {
            using var client = new HttpClient();
            var builder = new UriBuilder(NEWS_URL);
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["q"] = theme;
            query["language"] = "es";
            query["apiKey"] = "30a01aa6438d4782906f35bb2f136a91";
                
            builder.Query = query.ToString();

            string requestURL = builder.ToString();

            var content = await client.GetStringAsync(requestURL);

            return content;
        }
    }
}