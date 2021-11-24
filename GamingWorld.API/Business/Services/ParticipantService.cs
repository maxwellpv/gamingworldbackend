using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GamingWorld.API.Business.Domain.Models;
using GamingWorld.API.Business.Domain.Repositories;
using GamingWorld.API.Business.Domain.Services;
using GamingWorld.API.Business.Domain.Services.Communication;
using GamingWorld.API.Security.Domain.Repositories;
using GamingWorld.API.Security.Exceptions;
using GamingWorld.API.Shared.Domain.Repositories;

namespace GamingWorld.API.Business.Services
{
    public class ParticipantService : IParticipantService
    {
        
        private readonly IParticipantRepository _participantRepository;
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ParticipantService(IMapper mapper, IParticipantRepository participantRepository, IUnitOfWork unitOfWork, ITournamentRepository tournamentRepository)
        {
            _mapper = mapper;
            _participantRepository = participantRepository;
            _unitOfWork = unitOfWork;
            _tournamentRepository = tournamentRepository;
        }

        public async Task<IEnumerable<Participant>> ListAsync()
        {
            return await _participantRepository.ListAsync();
        }

        public async Task<ParticipantResponse> SaveAsync(int tournamentId, Participant participant)
        {
            var tournament = await _tournamentRepository.ListWithParticipantsById(tournamentId);
            if(tournament==null)
                return new ParticipantResponse("Tournament Not Found");
            if (tournament.Participants != null)
            {
                if (tournament.Participants.Count() >= tournament.ParticipantLimit)
                    return new ParticipantResponse("This tournament is full.");
                if (tournament.Participants.Any(x => x.UserId == participant.UserId))
                    return new ParticipantResponse("This user already is a participant.");
            }

            try
            {
                participant.TournamentId = tournamentId;
                await _participantRepository.AddAsync(participant);
                await _unitOfWork.CompleteAsync();

                return new ParticipantResponse(participant);
            }
            catch (Exception e)
            {
                return new ParticipantResponse($"An error occured while saving the publication: {e.Message}");
            }
        }

        public async Task<bool> ValidateParticipantTournament(int tournamentId, int participantId)
        {
            var tournament = await _tournamentRepository.ListWithParticipantsById(tournamentId);
            var participant = await _participantRepository.FindByIdAsync(participantId);
            if(tournament==null)
                return true;
            if (tournament.Participants != null)
            {
                if (tournament.Participants.Count() >= tournament.ParticipantLimit)
                    return false;
                if (tournament.Participants.Any(x => x.UserId == participant.UserId))
                    return false;
            }

            return true;
        }
        public async Task<ParticipantResponse> UpdateAsync(int id, Participant tournament)
        {
            var existingParticipant = GetById(id);
            if (existingParticipant == null)
                return new ParticipantResponse("Participant Not Found");
            existingParticipant.Points = tournament.Points;
            
            try
            {
                _participantRepository.Update(tournament);
                await _unitOfWork.CompleteAsync();
                return new ParticipantResponse(existingParticipant);
            }
            catch (Exception e)
            {
                return new ParticipantResponse($"An error occurred while updating the user: {tournament}");
            }
        }

        public async Task<ParticipantResponse> DeleteAsync(int id)
        {
            var existingParticipant =  GetById(id);

            if (existingParticipant == null)
                return new ParticipantResponse("Participant not found");
            try
            {
                _participantRepository.Remove(existingParticipant);
                await _unitOfWork.CompleteAsync();

                return new ParticipantResponse(existingParticipant);
            }
            catch (Exception e)
            {
                return new ParticipantResponse($"An error occurred while deleting participant:{e.Message}");
            }
        }
        
        private Participant GetById(int id)
        {
            var participant = _participantRepository.FindById(id);
            if (participant == null) throw new KeyNotFoundException("Participant not found.");
            return participant;
        }
        
    }
}