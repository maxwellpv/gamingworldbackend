using GamingWorld.API.Profiles.Domain.Models;

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