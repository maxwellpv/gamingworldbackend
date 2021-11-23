using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingWorld.API.Profiles.Domain.Models;
using GamingWorld.API.Profiles.Domain.Repositories;
using GamingWorld.API.Profiles.Domain.Services;
using GamingWorld.API.Profiles.Domain.Services.Communication;
using GamingWorld.API.Security.Domain.Repositories;
using IUnitOfWork = GamingWorld.API.Shared.Domain.Repositories.IUnitOfWork;

namespace GamingWorld.API.Profiles.Services
{
    public class ProfileService : IUProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProfileService(IProfileRepository profileRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _profileRepository = profileRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Profile>> ListAsync()
        {
            return await _profileRepository.ListAsync();
        }

        public async Task<Profile> ListByUserIdAsync(int userId)
        {
            return await _profileRepository.FindByUserId(userId);
        }

        public async Task<Profile> ListByIdAsync(int id)
        {
            return await _profileRepository.FindByIdAsync(id);
        }

        public async Task<ProfileResponse> SaveAsync(Profile profile)
        {
            var existingUserId = await _profileRepository.FindByUserId(profile.UserId);
            if (existingUserId != null)
                return new ProfileResponse("User already has a profile.");

            var user = await _userRepository.FindByIdAsync(profile.UserId);
            if (user == null)
                return new ProfileResponse("User not found");

            try
            {
                await _profileRepository.AddAsync(profile);
                await _unitOfWork.CompleteAsync();

                return new ProfileResponse(profile);
            }
            catch (Exception e)
            {
                return new ProfileResponse($"An error occurred while saving the profile: {e.Message}");
            }
        }

        public async Task<ProfileResponse> UpdateAsync(int id, Profile profile)
        {
            var existingProfile = await _profileRepository.FindByIdAsync(id);

            if (existingProfile == null)
                return new ProfileResponse("Profile not found.");
            
            existingProfile.GamingLevel = profile.GamingLevel;
            existingProfile.IsStreamer = profile.IsStreamer;
            existingProfile.GameExperiences = profile.GameExperiences;
            existingProfile.FavoriteGames = profile.FavoriteGames;
            existingProfile.StreamingCategories = profile.StreamingCategories;
            existingProfile.TournamentExperiences = profile.TournamentExperiences;

            try
            {
                _profileRepository.Update(existingProfile);
                await _unitOfWork.CompleteAsync();

                return new ProfileResponse(existingProfile);
            }
            catch (Exception e)
            {
                return new ProfileResponse($"An error occurred while updating the profile: {e.Message}");
            }
        }

        public async Task<ProfileResponse> DeleteAsync(int id)
        {
            var existingProfile = await _profileRepository.FindByIdAsync(id);

            if (existingProfile == null)
                return new ProfileResponse("Profile not found. ");

            try
            {
                _profileRepository.Remove(existingProfile);
                await _unitOfWork.CompleteAsync();

                return new ProfileResponse(existingProfile);
            }
            catch (Exception e)
            {
                return new ProfileResponse($"An error occurred while deleting the profile: {e.Message}");
            }
        }
    }
}