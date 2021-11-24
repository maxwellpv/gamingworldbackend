using GamingWorld.API.Profiles.Domain.Models;
using GamingWorld.API.Shared.Domain.Services.Communication;

namespace GamingWorld.API.Profiles.Domain.Services.Communication
{
    public class ProfileResponse : BaseResponse<Profile>
    {
        public ProfileResponse(string message) : base(message)
        {
        }

        public ProfileResponse(Profile profile) : base(profile)
        {
        }
    }
}