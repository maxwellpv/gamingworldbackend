﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GamingWorld.API.Shared.Extensions;
using GamingWorld.API.Users.Domain.Services;
using GamingWorld.API.Users.Resources;
using Microsoft.AspNetCore.Mvc;

namespace GamingWorld.API.Users.Controllers
{
    [Route("/api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Domain.Models.User>, IEnumerable<UserResource>>(users);
            return resources;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUserResource, Domain.Models.User>(resource);
            var result = await _userService.SaveAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var productResource = _mapper.Map<Domain.Models.User, UserResource>(result.Resource);
            return Ok(productResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUserResource, Domain.Models.User>(resource);
            var result = await _userService.UpdateAsync(id, user);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<Domain.Models.User, UserResource>(result.Resource);
            return Ok(userResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var productResource = _mapper.Map<Domain.Models.User, UserResource>(result.Resource);
            return Ok(productResource);
        }
    }
}