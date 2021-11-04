using GamingWorld.API.Domain.Models;

namespace GamingWorld.API.Domain.Services.Communication
{
    public class UserProfileResponse : BaseResponse<UserProfile>
    {
        public UserProfileResponse(string message) : base(message)
        {
        }

        public UserProfileResponse(UserProfile userProfile) : base(userProfile)
        {
        }
    }
}