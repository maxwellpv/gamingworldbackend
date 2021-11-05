using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.UserProfiles.Domain.Models;
using GamingWorld.API.UserProfiles.Domain.Repositories;
using GamingWorld.API.UserProfiles.Domain.Services;
using GamingWorld.API.UserProfiles.Domain.Services.Communication;
using GamingWorld.API.Users.Domain.Repositories;
using IUnitOfWork = GamingWorld.API.Users.Domain.Repositories.IUnitOfWork;

namespace GamingWorld.API.UserProfiles.Services
{
    public class UserProfileService : IUProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserProfileService(IUserProfileRepository userProfileRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userProfileRepository = userProfileRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<UserProfile>> ListAsync()
        {
            return await _userProfileRepository.ListAsync();
        }

        public async Task<UserProfile> ListByUserIdAsync(int userId)
        {
            return await _userProfileRepository.FindByUserId(userId);
        }

        public async Task<UserProfileResponse> SaveAsync(UserProfile userProfile)
        {
            var existingUserId = await _userProfileRepository.FindByUserId(userProfile.UserId);
            if (existingUserId != null)
                return new UserProfileResponse("User already has a profile.");

            var user = await _userRepository.FindByIdAsync(userProfile.UserId);
            if (user == null)
                return new UserProfileResponse("User not found");

            try
            {
                await _userProfileRepository.AddAsync(userProfile);
                await _unitOfWork.CompleteAsync();

                return new UserProfileResponse(userProfile);
            }
            catch (Exception e)
            {
                return new UserProfileResponse($"An error occurred while saving the profile: {e.Message}");
            }
        }

        public async Task<UserProfileResponse> UpdateAsync(int id, UserProfile userProfile)
        {
            var existingProfile = await _userProfileRepository.FindByIdAsync(id);

            if (existingProfile == null)
                return new UserProfileResponse("Profile not found.");

            var user = await _userRepository.FindByIdAsync(userProfile.UserId);
            if (user == null)
                return new UserProfileResponse("User not found");

            existingProfile.UserId = userProfile.UserId;
            existingProfile.GamingLevel = userProfile.GamingLevel;
            existingProfile.IsStreamer = userProfile.IsStreamer;

            try
            {
                _userProfileRepository.Update(existingProfile);
                await _unitOfWork.CompleteAsync();

                return new UserProfileResponse(existingProfile);
            }
            catch (Exception e)
            {
                return new UserProfileResponse($"An error occurred while updating the profile: {e.Message}");
            }
        }

        public async Task<UserProfileResponse> DeleteAsync(int id)
        {
            var existingProfile = await _userProfileRepository.FindByIdAsync(id);

            if (existingProfile == null)
                return new UserProfileResponse("Profile not found. ");

            try
            {
                _userProfileRepository.Remove(existingProfile);
                await _unitOfWork.CompleteAsync();

                return new UserProfileResponse(existingProfile);
            }
            catch (Exception e)
            {
                return new UserProfileResponse($"An error occurred while deleting the profile: {e.Message}");
            }
        }
    }
}