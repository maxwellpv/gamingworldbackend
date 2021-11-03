using AutoMapper;
using GamingWorld.API.Domain.Models;
using GamingWorld.API.Resources;

namespace GamingWorld.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();

            CreateMap<SaveUProfileResource, UserProfile>()
                .ForMember(target =>
                        target.GamingLevel,
                    options =>
                        options.MapFrom(source =>
                            (EGamingLevel) source.GamingLevel));
        }
    }
}