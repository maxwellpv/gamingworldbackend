using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Domain.Models;
using GamingWorld.API.Domain.Repositories;
using GamingWorld.API.Domain.Services;
using GamingWorld.API.Services.Communication;

namespace GamingWorld.API.Services
{
    public class UProfileService : IUProfileService
    {
        private readonly IUProfileRepository _uProfileRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UProfileService(IUProfileRepository uProfileRepository, IUnitOfWork unitOfWork)
        {
            _uProfileRepository = uProfileRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<UserProfile>> ListAsync()
        {
            return await _uProfileRepository.ListAsync();
        }

        public async Task<UserProfile> ListByUserIdAsync(int userId)
        {
            return await _uProfileRepository.FindByUserId(userId);
        }

        public async Task<UProfileResponse> SaveAsync(UserProfile userProfile)
        {
            var existingProfile = await _uProfileRepository.FindByIdAsync(userProfile.Id);

            if (existingProfile == null)
                return new UProfileResponse("Invalid Id");

            var existingUserId = await _uProfileRepository.FindByUserId(userProfile.UserId);
            if (existingUserId != null)
                return new UProfileResponse("UserId already exists");

            try
            {
                await _uProfileRepository.AddAsync(userProfile);
                await _unitOfWork.CompleteAsync();

                return new UProfileResponse(userProfile);
            }
            catch (Exception e)
            {
                return new UProfileResponse($"An error ocurred while saving the profile: {e.Message}");
            }
        }

        public async Task<UProfileResponse> UpdateAsync(int id, UserProfile userProfile)
        {
            var existingProfile = await _uProfileRepository.FindByIdAsync(id);

            if (existingProfile == null)
                return new UProfileResponse("Profile not found.");

            var existingUserId = await _uProfileRepository.FindByUserId(userProfile.UserId);
            if (existingUserId == null)
                return new UProfileResponse("User not found");

            existingProfile.UserId = userProfile.UserId;
            existingProfile.GamingLevel = userProfile.GamingLevel;
            existingProfile.IsStreamer = userProfile.IsStreamer;

            try
            {
                _uProfileRepository.Update(existingProfile);
                await _unitOfWork.CompleteAsync();

                return new UProfileResponse(existingProfile);
            }
            catch (Exception e)
            {
                return new UProfileResponse($"An error occurred while updating the profile: {e.Message}");
            }
        }

        public async Task<UProfileResponse> DeleteAsync(int id)
        {
            var existingProfile = await _uProfileRepository.FindByIdAsync(id);

            if (existingProfile == null)
                return new UProfileResponse("Profile not found. ");

            try
            {
                _uProfileRepository.Remove(existingProfile);
                await _unitOfWork.CompleteAsync();

                return new UProfileResponse(existingProfile);
            }
            catch (Exception e)
            {
                return new UProfileResponse($"An error occurred while deleting the profile: {e.Message}");
            }
        }
    }
}