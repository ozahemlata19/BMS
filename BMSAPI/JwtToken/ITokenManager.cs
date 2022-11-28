﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSAPI.JwtToken
{
    public interface ITokenManager
    {
        string GenerateJsonWebToken(string userName);
        bool ValidateToken(string authToken);
    }
}
