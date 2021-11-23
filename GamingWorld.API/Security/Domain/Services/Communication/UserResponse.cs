using GamingWorld.API.Profiles.Domain.Services.Communication;
using GamingWorld.API.Publications.Domain.Services.Communication;
using GamingWorld.API.Security.Domain.Models;
using GamingWorld.API.Shared.Domain.Services.Communication;

namespace GamingWorld.API.Security.Domain.Services.Communication
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(string message) : base(message)
        {
        }

        public UserResponse(User user) : base(user)
        {
        }
    }
}