using System;
using System.Threading.Tasks;
using GamingWorld.API.Shared.Inbound.News.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamingWorld.API.Shared.Inbound.News.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        
        [HttpGet]
        public async Task<String> GetRandomListAsync(string theme)
        {
            return await _newsService.ListByTheme(theme);
        }
    }
}