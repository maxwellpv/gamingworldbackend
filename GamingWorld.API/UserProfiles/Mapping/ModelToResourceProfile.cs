using AutoMapper;
using GamingWorld.API.Shared.Extensions;
using GamingWorld.API.UserProfiles.Domain.Models;
using GamingWorld.API.UserProfiles.Resources;

namespace GamingWorld.API.UserProfiles.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<UserProfile, UserProfileResource>()
                .ForMember(
                    target =>
                        target.GamingLevel,
                    options =>
                        options.MapFrom(source =>
                            source.GamingLevel.ToDescriptionString()));
        }
        
    }
}