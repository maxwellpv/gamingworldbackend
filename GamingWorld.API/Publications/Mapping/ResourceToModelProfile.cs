using AutoMapper;
using GamingWorld.API.Publications.Domain.Models;
using GamingWorld.API.Publications.Resources;

namespace GamingWorld.API.Publications.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePublicationResource, Publication>();
        }
    }
}