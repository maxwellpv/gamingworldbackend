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
        [HttpGet("{id}")]
        public async Task<TournamentResource> GetByIdAsync(int id)
        {
            var tournament =  await _tournamentService.GetById(id);
            var resource = _mapper.Map<Tournament, TournamentResource>(tournament);
            return resource;
        }
        [HttpGet("{id}/participants")]
        public async Task<IEnumerable<ParticipantResource>> GetAllParticipantsByTournamentIdAsync(int id)
        {
            var tournament =  await _tournamentService.ListWithParticipantsByIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Participant>, IEnumerable<ParticipantResource>>(tournament.Participants);
            return resources;
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

        public async Task<IActionResult> PostParticipantAsync([FromBody] SaveParticipantResource resource, int id)
        {

            if (!ModelState.IsValid)
                 return BadRequest(ModelState.GetErrorMessages());

            var participant = _mapper.Map<SaveParticipantResource, Participant>(resource);
            var result = await _participantService.SaveAsync(id, participant);

            if (!result.Success)
                return BadRequest(result.Message);

            var participantResource = _mapper.Map<Participant, ParticipantResource>(result.Resource);
            return Ok(participantResource);
        }
        [HttpPut("{id}/participants/{participantId}")]
        public async Task<IActionResult> PutAsync(int id,int participantId, [FromQuery] int points)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var result = await _tournamentService.UpdateParticipantPoints(id,participantId, points);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<Participant, ParticipantResource>(result.Resource);
            return Ok(profileResource);

        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromQuery] bool tournamentStatus, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var result = await _tournamentService.EndTournament(id, tournamentStatus);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var tournamentResource = _mapper.Map<Tournament, TournamentResource>(result.Resource);
            return Ok(tournamentResource);

        }
    }
}