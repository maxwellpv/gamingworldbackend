using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GamingWorld.API.Business.Domain.Models;
using GamingWorld.API.Business.Domain.Services;
using GamingWorld.API.Business.Resources;
using GamingWorld.API.Publications.Domain.Models;
using GamingWorld.API.Publications.Resources;
using GamingWorld.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GamingWorld.API.Business.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class TournamentsController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;
        private readonly IParticipantService _participantService;
        private readonly IMapper _mapper;

        public TournamentsController(IMapper mapper, ITournamentService tournamentService, IParticipantService participantService)
        {
            _mapper = mapper;
            _tournamentService = tournamentService;
            _participantService = participantService;
        }

        [HttpGet]
        public async Task<IEnumerable<TournamentResource>> GetAllAsync()
        {
                var publications = await _tournamentService.ListAsync();
                var resources = _mapper.Map<IEnumerable<Tournament>, IEnumerable<TournamentResource>>(publications);
                return resources;
        }
        [HttpGet("{id}/participants")]
        public async Task<Tournament> GetAllParticipantsByTournamentIdAsync(int id)
        {
            var participants = await _tournamentService.ListWithParticipantsByIdAsync(id);
            //var resources = _mapper.Map<IEnumerable<Tournament>, IEnumerable<TournamentResource>>(publications);
            return participants;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveTournamentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var publication = _mapper.Map<SaveTournamentResource, Tournament>(resource);
            var result = await _tournamentService.SaveAsync(publication);

            if (!result.Success)
                return BadRequest(result.Message);
            var publicationResource = _mapper.Map<Tournament, SaveTournamentResource>(result.Resource);
            return Ok(publicationResource);
        }

        [HttpPost( "{id}/participants")]

        public async Task<IActionResult> PostParticipantAsync([FromBody] Participant resource)
        {
            /*if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var publication = _mapper.Map<SaveTournamentResource, Tournament>(resource);*/
            
            var result = await _participantService.SaveAsync(resource);
            return Ok(resource);

            /*if (!result.Success)
                return BadRequest(result.Message);
            var publicationResource = _mapper.Map<Tournament, SaveTournamentResource>(result.Resource);
            return Ok(publicationResource);*/
        }
    }
}