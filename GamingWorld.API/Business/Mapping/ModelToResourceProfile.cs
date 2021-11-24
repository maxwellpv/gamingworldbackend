using AutoMapper;
using GamingWorld.API.Business.Domain.Models;
using GamingWorld.API.Business.Resources;
using GamingWorld.API.Publications.Domain.Models;
using GamingWorld.API.Publications.Resources;

namespace GamingWorld.API.Business.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Tournament, TournamentResource>();
            CreateMap<Participant, SaveParticipantResource>();
            CreateMap<Participant, ParticipantResource>();
            CreateMap<Tournament, SaveTournamentResource>();
        }
        
    }
}