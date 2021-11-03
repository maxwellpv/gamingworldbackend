using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GamingWorld.API.Domain.Models;
using GamingWorld.API.Domain.Services;
using GamingWorld.API.Extensions;
using GamingWorld.API.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GamingWorld.API.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UProfileController : ControllerBase
    {
        private readonly IUProfileService _uProfileService;
        private readonly IMapper _mapper;

        public UProfileController(IUProfileService uProfileService, IMapper mapper)
        {
            _uProfileService = uProfileService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<UProfileResource>> GetAllAsync()
        {
            var profiles = await _uProfileService.ListAsync();
            var resources = _mapper.Map<IEnumerable<UserProfile>, IEnumerable<UProfileResource>>(profiles);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var profile = _mapper.Map<SaveUProfileResource, UserProfile>(resource);
            var result = await _uProfileService.SaveAsync(profile);

            if (!result.Success)
                return BadRequest(result.Message);

            var userProfileResource = _mapper.Map<UserProfile, UProfileResource>(result.Resource);
            return Ok(userProfileResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var profile = _mapper.Map<SaveUProfileResource, UserProfile>(resource);
            var result = await _uProfileService.UpdateAsync(id, profile);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<UserProfile, UProfileResource>(result.Resource);
            return Ok(profileResource);

        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _uProfileService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<UserProfile, UProfileResource>(result.Resource);
            return Ok(profileResource);
        }
    }

    
}