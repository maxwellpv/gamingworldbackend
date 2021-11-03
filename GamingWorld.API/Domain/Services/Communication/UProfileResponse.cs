using GamingWorld.API.Domain.Models;

namespace GamingWorld.API.Services.Communication
{
    public class UProfileResponse : BaseResponse<UserProfile>
    {
        public UProfileResponse(string message) : base(message)
        {
        }

        public UProfileResponse(UserProfile userProfile) : base(userProfile)
        {
        }
    }
}