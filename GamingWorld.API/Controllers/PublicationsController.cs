using System.Collections.Generic;
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
        public async Task<IEnumerable<PublicationResource>> GetAllAsync()
        {
            var publications = await _publicationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Publication>, IEnumerable<PublicationResource>>(publications);
            return resources;
        }
    }
}