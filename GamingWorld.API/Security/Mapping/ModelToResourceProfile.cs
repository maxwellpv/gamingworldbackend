using AutoMapper;
using GamingWorld.API.Security.Domain.Models;
using GamingWorld.API.Security.Domain.Services.Communication;
using GamingWorld.API.Security.Resources;

namespace GamingWorld.API.Security.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, AuthenticateResponse>();
            
            CreateMap<User, UserResource>();

        }
    }
}