using HCMUS.src.Modules.Auth.dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HCMUS.src.Modules.Auth.AuthModule;

namespace HCMUS.src.Modules.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authservice;

        public AuthController(IAuthService authservice)
        {
            _authservice = authservice;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //return Ok("ssss");
            return Ok(await _authservice.GetAllUsers());
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(LoginRequest loginRequest)
        {
            var ssss = loginRequest.Email;
            string response = await _authservice.Authencate(loginRequest);
            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect." });
            }
            return Ok(new { token = response });
        }



    }
}
