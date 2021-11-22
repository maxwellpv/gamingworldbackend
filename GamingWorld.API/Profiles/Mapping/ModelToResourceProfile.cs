using AutoMapper;
using GamingWorld.API.Profiles.Domain.Models;
using GamingWorld.API.Profiles.Resources;
using GamingWorld.API.Shared.Extensions;
using Profile = GamingWorld.API.Profiles.Domain.Models.Profile;

namespace GamingWorld.API.Profiles.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Profile, ProfileResource>()
                .ForMember(
                    target =>
                        target.GamingLevel,
                    options =>
                        options.MapFrom(source =>
                            source.GamingLevel.ToDescriptionString()));
        }
        
    }
}