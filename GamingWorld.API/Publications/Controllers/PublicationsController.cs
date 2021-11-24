﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GamingWorld.API.Business.Domain.Models;
using GamingWorld.API.Business.Domain.Services;
using GamingWorld.API.Business.Resources;
using GamingWorld.API.Business.Services;
using GamingWorld.API.Publications.Domain.Models;
using GamingWorld.API.Publications.Domain.Services;
using GamingWorld.API.Publications.Resources;
using GamingWorld.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GamingWorld.API.Publications.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PublicationsController : ControllerBase
    {
        private readonly IPublicationService _publicationService;
        private readonly ITournamentService _tournamentService;
        private readonly IMapper _mapper;

        public PublicationsController(IPublicationService publicationService, IMapper mapper, ITournamentService tournamentService)
        {
            _publicationService = publicationService;
            _mapper = mapper;
            _tournamentService = tournamentService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<PublicationResource>> GetAllAsync([FromQuery] int ?publicationType)
        {
            
            if (publicationType != null)
            {
                var publications = await _publicationService.ListByTypeAsync((int)publicationType);
                var resources = _mapper.Map<IEnumerable<Publication>, IEnumerable<PublicationResource>>(publications);
                return resources;
            }
            else
            {
                var publications = await _publicationService.ListAsync();
                var resources = _mapper.Map<IEnumerable<Publication>, IEnumerable<PublicationResource>>(publications);
                return resources;
            }
            
        }
        
        [HttpGet("{id}")]
        public async Task<PublicationResource> GetById(int id)
        {
            var publication = await _publicationService.GetById(id);
            var resource = _mapper.Map<Publication, PublicationResource>(publication);
            return resource;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePublicationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var publicationResult = await _publicationService.SaveAsync(resource);


            if (!publicationResult.Success)
                return BadRequest(publicationResult.Message);

            var publicationResource = _mapper.Map<Publication, PublicationResource>(publicationResult.Resource);
            return Ok(publicationResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePublicationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var publication = _mapper.Map<SavePublicationResource, Publication>(resource);
            var result = await _publicationService.UpdateAsync(id, publication);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
            return Ok(publicationResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _publicationService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var categoryResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
            return Ok(categoryResource);
        }
        
        
    }
}