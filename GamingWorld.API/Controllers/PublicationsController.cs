using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GamingWorld.API.Domain.Models;
using GamingWorld.API.Domain.Services;
using GamingWorld.API.Extensions;
using GamingWorld.API.Resources;


namespace GamingWorld.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PublicationsController : ControllerBase
    {
        private readonly IPublicationService _publicationService;
        private readonly IMapper _mapper;

        public PublicationsController(IPublicationService publicationService, IMapper mapper)
        {
            _publicationService = publicationService;
            _mapper = mapper;
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
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePublicationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var publication = _mapper.Map<SavePublicationResource, Publication>(resource);
            var result = await _publicationService.SaveAsync(publication);

            if (!result.Success)
                return BadRequest(result.Message);
            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
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