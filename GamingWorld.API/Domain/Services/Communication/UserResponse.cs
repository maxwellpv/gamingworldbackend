using GamingWorld.API.Domain.Models;

namespace GamingWorld.API.Domain.Services.Communication
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