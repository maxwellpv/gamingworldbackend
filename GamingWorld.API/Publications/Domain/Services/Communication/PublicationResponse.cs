using GamingWorld.API.Publications.Domain.Models;
using GamingWorld.API.Shared.Domain.Services.Communication;

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