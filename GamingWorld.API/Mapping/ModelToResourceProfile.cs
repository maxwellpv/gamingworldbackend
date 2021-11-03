using AutoMapper;
using GamingWorld.API.Domain.Models;
using GamingWorld.API.Extensions;
using GamingWorld.API.Resources;

namespace GamingWorld.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();

            CreateMap<UserProfile, UProfileResource>()
                .ForMember(
                    target =>
                        target.GamingLevel,
                    options =>
                        options.MapFrom(source =>
                            source.GamingLevel.ToDescriptionString()));
        }
        
    }
}