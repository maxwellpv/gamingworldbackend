using AutoMapper;
using GamingWorld.API.Users.Resources;

namespace GamingWorld.API.Users.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, Users.Domain.Models.User>();
           
        }
    }
}