using System.ComponentModel;

namespace GamingWorld.API.UserProfiles.Domain.Models
{
    public enum EGameExperienceTime: short
    {
        [Description("Days")]
        D = 1,
        [Description("Months")]
        M = 2,
        [Description("Years")]
        Y = 3,
    }
}