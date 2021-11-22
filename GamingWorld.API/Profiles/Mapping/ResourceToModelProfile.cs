using AutoMapper;
using GamingWorld.API.Profiles.Domain.Models;
using GamingWorld.API.Profiles.Resources;
using Profile = GamingWorld.API.Profiles.Domain.Models.Profile;

namespace GamingWorld.API.Profiles.Mapping
{
    public class ResourceToModelProfile : AutoMapper.Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveProfileResource, Profile>()
                .ForMember(target =>
                        target.GamingLevel,
                    options =>
                        options.MapFrom(source =>
                            (EGamingLevel) source.GamingLevel));
        }
    }
}