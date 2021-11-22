using AutoMapper;
using GamingWorld.API.Security.Domain.Models;
using GamingWorld.API.Security.Domain.Services.Communication;
using GamingWorld.API.Security.Resources;

namespace GamingWorld.API.Security.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
            CreateMap<RegisterRequest, User>();
            CreateMap<UpdateRequest, User>()
                .ForAllMembers(options=>options.Condition(
                    (source, Target, property) =>
                    {
                        if (property == null) return false;
                        if(property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                        return true;
                    }));
           
        }
    }
}