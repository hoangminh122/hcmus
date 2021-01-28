using HCMUS.src.Entities.Auth;
using HCMUS.src.Modules.Auth.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HCMUS.src.Modules.Auth.dto.register_request;

namespace HCMUS.src.Modules.Auth
{
    public class AuthModule
    {
        public interface IAuthService
        {
            Task<string> Authencate(LoginRequest request);
            Task<bool> Register(RegisterRequest request);
            Task<IEnumerable<Users>> GetAllUsers();

        }
    }
}
