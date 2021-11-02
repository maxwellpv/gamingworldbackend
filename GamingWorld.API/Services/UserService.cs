using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Domain.Models;
using GamingWorld.API.Domain.Repositories;
using GamingWorld.API.Domain.Services;
using GamingWorld.API.Services.Communication;

namespace GamingWorld.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }
        
        public async Task<User> ListByUserIdAsync(int userId)
        {
            return await _userRepository.FindByIdAsync(userId);
        }
        
        public async Task<User> ListByUserUsernameAsync(int userId)
        {
            return await _userRepository.FindByIdAsync(userId);
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            //Validate Username
            
            var existingUsername = await _userRepository.FindByUsernameAsync(user.Username);
            if (existingUsername != null)
                return new UserResponse("Username already exists.");

            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred while saving the user: {e.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            //Validate Id
            var existingUserById = await _userRepository.FindByIdAsync(id);

            if (existingUserById == null)
                return new UserResponse("User not found.");

            //Validate Username
            var existingUserByUsername = await _userRepository.FindByUsernameAsync(user.Username);
            if (existingUserByUsername != null && existingUserByUsername.Id != id)
                return new UserResponse("Username already used.");
            
            //Validate Email
            var existingUserByEmail = await _userRepository.FindByEmailAsync(user.Email);
            if (existingUserByEmail != null && existingUserByEmail.Id != id)
                return new UserResponse("Email already used.");

            existingUserById.Email = user.Email;
            existingUserById.Username = user.Username;
            existingUserById.Password = user.Password;
            existingUserById.Premium = user.Premium;

            try
            {
                _userRepository.Update(existingUserById);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUserById);

            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred while updating the user: {e.Message}");
            }

        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            //Validate User Id
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser == null)
                return new UserResponse("User not found.");

            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);

            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred while deleting the user: {e.Message}");
            }
        }
    }
}