using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GamingWorld.API.Profiles.Domain.Models;
using GamingWorld.API.Profiles.Domain.Services;
using GamingWorld.API.Profiles.Resources;
using GamingWorld.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Profile = GamingWorld.API.Profiles.Domain.Models.Profile;

namespace GamingWorld.API.Profiles.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly IUProfileService _uProfileService;
        private readonly IMapper _mapper;

        public ProfilesController(IUProfileService uProfileService, IMapper mapper)
        {
            _uProfileService = uProfileService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ProfileResource>> GetAllAsync()
        {
            var profiles = await _uProfileService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Profile>, IEnumerable<ProfileResource>>(profiles);
            return resources;
        }
        
        [HttpGet("{id}")]
        public async Task<ProfileResource> GetById(int id)
        {
            var profile = await _uProfileService.ListByIdAsync(id);
            var resources = _mapper.Map<Profile, ProfileResource>(profile);
            return resources;
        }
        
        [HttpGet("user/{userId}")]
        public async Task<ProfileResource> GetByUserId(int userId)
        {
            var profile = await _uProfileService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<Profile, ProfileResource>(profile);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var profile = _mapper.Map<SaveProfileResource, Profile>(resource);
            var result = await _uProfileService.SaveAsync(profile);

            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<Profile, ProfileResource>(result.Resource);
            return Ok(profileResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var profile = _mapper.Map<SaveProfileResource, Profile>(resource);
            var result = await _uProfileService.UpdateAsync(id, profile);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<Profile, ProfileResource>(result.Resource);
            return Ok(profileResource);

        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _uProfileService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<Profile, ProfileResource>(result.Resource);
            return Ok(profileResource);
        }
    }

    
}