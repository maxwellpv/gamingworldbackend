using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GamingWorld.API.Shared.Extensions;
using GamingWorld.API.UserProfiles.Domain.Models;
using GamingWorld.API.UserProfiles.Domain.Services;
using GamingWorld.API.UserProfiles.Resources;
using Microsoft.AspNetCore.Mvc;

namespace GamingWorld.API.UserProfiles.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UserProfilesController : ControllerBase
    {
        private readonly IUProfileService _uProfileService;
        private readonly IMapper _mapper;

        public UserProfilesController(IUProfileService uProfileService, IMapper mapper)
        {
            _uProfileService = uProfileService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<UserProfileResource>> GetAllAsync()
        {
            var profiles = await _uProfileService.ListAsync();
            var resources = _mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileResource>>(profiles);
            return resources;
        }
        
        [HttpGet("{id}")]
        public async Task<UserProfileResource> GetById(int id)
        {
            var profile = await _uProfileService.ListByUserIdAsync(id);
            var resources = _mapper.Map<UserProfile, UserProfileResource>(profile);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var profile = _mapper.Map<SaveUserProfileResource, UserProfile>(resource);
            var result = await _uProfileService.SaveAsync(profile);

            if (!result.Success)
                return BadRequest(result.Message);

            var userProfileResource = _mapper.Map<UserProfile, UserProfileResource>(result.Resource);
            return Ok(userProfileResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var profile = _mapper.Map<SaveUserProfileResource, UserProfile>(resource);
            var result = await _uProfileService.UpdateAsync(id, profile);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<UserProfile, UserProfileResource>(result.Resource);
            return Ok(profileResource);

        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _uProfileService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<UserProfile, UserProfileResource>(result.Resource);
            return Ok(profileResource);
        }
    }

    
}