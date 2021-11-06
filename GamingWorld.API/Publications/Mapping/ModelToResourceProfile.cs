using AutoMapper;
using GamingWorld.API.Publications.Domain.Models;
using GamingWorld.API.Publications.Resources;
using GamingWorld.API.Users.Resources;

namespace GamingWorld.API.Publications.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Publication, PublicationResource>();
        }
        
    }
}