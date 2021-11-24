using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Shared.Inbound.Games.Domain.Models;
using GamingWorld.API.Shared.Inbound.Games.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamingWorld.API.Shared.Inbound.Games.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _gamesService;
        private readonly int DEFAULT_LIMIT = 10;

        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Game>> GetRandomListAsync(int limit)
        {
            return await _gamesService.ListRandomAsync(limit);
        }

        [HttpGet("{id}")]
        public async Task<Game> GetByIdAsync(int id)
        {
            return await _gamesService.GetById(id);
        }
        
        
        [HttpGet("find/{name}")]
        public async Task<IEnumerable<Game>> GetByNameAsync(string name, int limit)
        {
            return await _gamesService.FindByName(name, limit);
        }
    }
}