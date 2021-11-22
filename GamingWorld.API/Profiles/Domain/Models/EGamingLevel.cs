﻿using System.ComponentModel;

namespace GamingWorld.API.Profiles.Domain.Models
{
    public enum EGamingLevel : short
    {
        [Description("Newbie")]
        N = 1,
        [Description("Medium")]
        M = 2,
        [Description("Advanced")]
        A = 3,
    }
}