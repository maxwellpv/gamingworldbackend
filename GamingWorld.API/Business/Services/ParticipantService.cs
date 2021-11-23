using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GamingWorld.API.Business.Domain.Models;
using GamingWorld.API.Business.Domain.Repositories;
using GamingWorld.API.Business.Domain.Services;
using GamingWorld.API.Business.Domain.Services.Communication;
using GamingWorld.API.Security.Exceptions;
using GamingWorld.API.Shared.Domain.Repositories;

namespace GamingWorld.API.Business.Services
{
    public class ParticipantService : IParticipantService
    {
        
        private readonly IParticipantRepository _participantRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ParticipantService(IMapper mapper, IParticipantRepository participantRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _participantRepository = participantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Participant>> ListAsync()
        {
            return await _participantRepository.ListAsync();
        }

        public Task<Participant> ListByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Participant>> ListByTypeAsync()
        {
            throw new NotImplementedException();
        }

        

        public async Task<ParticipantResponse> SaveAsync(Participant participant)
        {
            try
            {
                await _participantRepository.AddAsync(participant);
                await _unitOfWork.CompleteAsync();

                return new ParticipantResponse(participant);
            }
            catch (Exception e)
            {
                return new ParticipantResponse($"An error occured while saving the publication: {e.Message}");
            }
        }

        public async Task<ParticipantResponse> UpdateAsync(int id, Participant tournament)
        {
            var existingTournament = GetById(id);
            if (existingTournament == null)
                return new ParticipantResponse("Tournament Not Found");
            existingTournament.Points = tournament.Points;
            
            try
            {
                _participantRepository.Update(tournament);
                await _unitOfWork.CompleteAsync();
                return new ParticipantResponse(existingTournament);
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
                return new ParticipantResponse("Tournament not found");
            try
            {
                _participantRepository.Remove(existingParticipant);
                await _unitOfWork.CompleteAsync();

                return new ParticipantResponse(existingParticipant);
            }
            catch (Exception e)
            {
                return new ParticipantResponse($"An error occurred while deleting publication:{e.Message}");
            }
        }
        
        private Participant GetById(int id)
        {
            var user = _participantRepository.FindById(id);
            if (user == null) throw new KeyNotFoundException("User not found.");
            return user;
        }
        
    }
}