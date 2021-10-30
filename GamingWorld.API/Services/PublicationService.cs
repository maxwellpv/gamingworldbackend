using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamingWorld.API.Domain.Models;
using GamingWorld.API.Domain.Repositories;
using GamingWorld.API.Domain.Services;
using GamingWorld.API.Domain.Services.Communication;

namespace GamingWorld.API.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PublicationService(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork)
        {
            _publicationRepository = publicationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _publicationRepository.ListAsync();
        }

        public async Task<PublicationResponse> SaveAsync(Publication publication)
        {
            try
            {
                await _publicationRepository.AddAsync(publication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(publication);
            }
            catch (Exception e)
            {
                return new PublicationResponse($"An error occured while saving the publication: {e.Message}");
            }
        }

        public async Task<PublicationResponse> UpdateAsync(int id, Publication publication)
        {
            var existingPublication = await _publicationRepository.FindByIdAsync(id);
            if (existingPublication == null)
                return new PublicationResponse("Publication Not Found");
            existingPublication.Title = publication.Title;

            try
            {
                _publicationRepository.Update(existingPublication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(existingPublication);
            }
            catch (Exception e)
            {
                return new PublicationResponse($"An error occurred while updating the publication: {e.Message}");
            }
        }

        public async Task<PublicationResponse> DeleteAsync(int id)
        {
            var existingPublication = await _publicationRepository.FindByIdAsync(id);

            if (existingPublication == null)
                return new PublicationResponse("Publication not found");
            try
            {
                _publicationRepository.Remove(existingPublication);
                await _unitOfWork.CompleteAsync();

                return new PublicationResponse(existingPublication);
            }
            catch (Exception e)
            {
                return new PublicationResponse($"An error occurred while deleting publication:{e.Message}");
            }
        }
    }
}