using AutoMapper;
using GamingWorld.API.Business.Domain.Models;
using GamingWorld.API.Business.Resources;
using GamingWorld.API.Publications.Domain.Models;
using GamingWorld.API.Publications.Resources;

namespace GamingWorld.API.Business.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Tournament, TournamentResource>();
            CreateMap<Tournament, SaveTournamentResource>();
        }
        
    }
}