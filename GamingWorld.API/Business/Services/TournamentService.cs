using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GamingWorld.API.Business.Domain.Models;
using GamingWorld.API.Business.Domain.Repositories;
using GamingWorld.API.Business.Domain.Services;
using GamingWorld.API.Business.Domain.Services.Communication;
using GamingWorld.API.Business.Resources;
using GamingWorld.API.Security.Exceptions;
using GamingWorld.API.Shared.Domain.Repositories;

namespace GamingWorld.API.Business.Services
{
    public class TournamentService : ITournamentService
    {
        
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TournamentService(IMapper mapper, ITournamentRepository tournamentRepository, IUnitOfWork unitOfWork, IParticipantRepository participantRepository)
        {
            _mapper = mapper;
            _tournamentRepository = tournamentRepository;
            _unitOfWork = unitOfWork;
            _participantRepository = participantRepository;
        }

        public async Task<IEnumerable<Tournament>> ListAsync()
        {
            return await _tournamentRepository.ListAsync();
        }

        public async Task<TournamentResponse> SaveAsync(Tournament tournament)
        {
            //Validate
            
            try
            {
                await _tournamentRepository.AddAsync(tournament);
                await _unitOfWork.CompleteAsync();

                return new TournamentResponse(tournament);
            }
            catch (Exception e)
            {
                return new TournamentResponse($"An error occured while saving the publication: {e.Message}");
            }
        }

        public async Task<Tournament> ListWithParticipantsByIdAsync(int tournamentId)
        {
            return await _tournamentRepository.ListWithParticipantsById(tournamentId);
        }

        public async Task<ParticipantResponse> UpdateParticipantPoints(int tournamentId, int participantId, int points)
        {
            var existingTournament = await _tournamentRepository.FindByIdAsync(tournamentId);
            if (existingTournament == null)
                return new ParticipantResponse("Tournament Not Found");
            
            var existingParticipant = await _participantRepository.FindByIdAsync(participantId);
            if (existingParticipant == null)
                return new ParticipantResponse("Participant Not Found");
            
            if (points < 0)
                return new ParticipantResponse("Points must be positive.");
            
            try
            {
                existingParticipant.Points = points;
                _participantRepository.Update(existingParticipant);
                await _unitOfWork.CompleteAsync();
                return new ParticipantResponse(existingParticipant);
            }
            catch (Exception e)
            {
                return new ParticipantResponse($"An error occurred while updating the participant.");
            }
        }

        public async Task<TournamentResponse> UpdateAsync(int id, Tournament tournament)
        {
            var existingTournament = await _tournamentRepository.FindByIdAsync(id);
            if (existingTournament == null)
                return new TournamentResponse("Tournament Not Found");
            existingTournament.Id = tournament.Id;
            
            try
            {
                _tournamentRepository.Update(tournament);
                await _unitOfWork.CompleteAsync();
                return new TournamentResponse(existingTournament);
            }
            catch (Exception e)
            {
                return new TournamentResponse($"An error occurred while updating the user: {tournament}");
            }
        }

        public async Task<TournamentResponse> DeleteAsync(int id)
        {
            var existingTournament =  await GetById(id);

            if (existingTournament == null)
                return new TournamentResponse("Tournament not found");
            try
            {
                _tournamentRepository.Remove(existingTournament);
                await _unitOfWork.CompleteAsync();

                return new TournamentResponse(existingTournament);
            }
            catch (Exception e)
            {
                return new TournamentResponse($"An error occurred while deleting publication:{e.Message}");
            }
        }
        
        public async Task<Tournament> GetById(int id)
        {
            var tournament = await _tournamentRepository.FindByIdAsync(id);
            await _unitOfWork.CompleteAsync();
            if (tournament == null) throw new KeyNotFoundException("Tournament not found.");
            return tournament;
        }

        public async Task<TournamentResponse> EndTournament(int id, bool status)
        {
            var tournament = await _tournamentRepository.FindByIdAsync(id);
            await _unitOfWork.CompleteAsync();
            if (tournament == null) throw new KeyNotFoundException("Tournament not found.");
            tournament.TournamentStatus = status;
            _tournamentRepository.Update(tournament);
            await _unitOfWork.CompleteAsync();
            return new TournamentResponse(tournament);
            
        }
        
    }
}