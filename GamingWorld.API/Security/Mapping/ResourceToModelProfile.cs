using AutoMapper;
using GamingWorld.API.Security.Domain.Models;
using GamingWorld.API.Security.Resources;

namespace GamingWorld.API.Security.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
           
        }
    }
}