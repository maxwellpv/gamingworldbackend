using GamingWorld.API.Publications.Domain.Models;

namespace GamingWorld.API.Publications.Domain.Services.Communication
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