using AutoMapper;
using GamingWorld.API.Users.Resources;

namespace GamingWorld.API.Users.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Users.Domain.Models.User, UserResource>();

        }
    }
}