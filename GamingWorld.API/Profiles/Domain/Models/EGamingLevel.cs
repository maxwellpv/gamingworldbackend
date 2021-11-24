using System.ComponentModel;

namespace GamingWorld.API.Profiles.Domain.Models
{
    public enum EGamingLevel : short
    {
        [Description("Newbie")]
        Newbie = 1,
        [Description("Medium")]
        Medium = 2,
        [Description("Advanced")]
        Advanced = 3,
    }
}