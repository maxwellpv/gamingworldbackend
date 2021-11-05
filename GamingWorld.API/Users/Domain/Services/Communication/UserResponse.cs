using GamingWorld.API.UserProfiles.Domain.Services.Communication;

namespace GamingWorld.API.Users.Domain.Services.Communication
{
    public class UserResponse : BaseResponse<Users.Domain.Models.User>
    {
        public UserResponse(string message) : base(message)
        {
        }

        public UserResponse(Users.Domain.Models.User user) : base(user)
        {
        }
    }
}