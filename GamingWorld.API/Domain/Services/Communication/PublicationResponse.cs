using GamingWorld.API.Domain.Models;

namespace GamingWorld.API.Domain.Services.Communication
{
    public class PublicationResponse : BaseResponse<Publication>
    {
        public PublicationResponse(string message) : base(message)
        {
        }

        public PublicationResponse(Publication publication) : base(publication)
        {
        }
    }
}