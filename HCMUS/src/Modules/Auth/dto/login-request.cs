﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCMUS.src.Modules.Auth.dto
{
    public class LoginRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string RememberMe { get; set; }

    }
}
