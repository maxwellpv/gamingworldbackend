using AutoMapper;
using GamingWorld.API.Publications.Domain.Models;
using GamingWorld.API.Publications.Resources;
using GamingWorld.API.UserProfiles.Domain.Models;
using GamingWorld.API.UserProfiles.Extensions;
using GamingWorld.API.UserProfiles.Resources;
using GamingWorld.API.Users.Resources;

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