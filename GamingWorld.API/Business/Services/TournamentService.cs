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
    public class TournamentService : ITournamentService
    {
        
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TournamentService(IMapper mapper, ITournamentRepository tournamentRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _tournamentRepository = tournamentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Tournament>> ListAsync()
        {
            return await _tournamentRepository.ListAsync();
        }

        public Task<Tournament> ListByUserIdAsync(int userId)
        {
            throw new System.NotImplementedException();
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

        public async Task<TournamentResponse> UpdateAsync(int id, Tournament tournament)
        {
            var existingTournament = await _tournamentRepository.FindByIdAsync(id);
            if (existingTournament == null)
                return new TournamentResponse("Tournament Not Found");
            existingTournament.PublicationId = tournament.PublicationId;
            
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
            var existingTournament =  GetById(id);

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
        
        private Tournament GetById(int id)
        {
            var user = _tournamentRepository.FindById(id);
            if (user == null) throw new KeyNotFoundException("User not found.");
            return user;
        }
        
    }
}