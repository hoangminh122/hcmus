using HCMUS.src.Modules.Auth.dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HCMUS.src.Modules.Auth.AuthModule;
using static HCMUS.src.Modules.Auth.dto.register_request;

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

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (string.IsNullOrWhiteSpace(registerRequest.Password))
                return BadRequest(new { message = "Password is required" });
            //find user
            var user = await _authservice.GetUsersByEmailAsync(registerRequest.Email);
            if (user != null)
            {
                return BadRequest(new { message = "Email is already taken" });
            }

            var isSaved = await _authservice.Register(registerRequest);
            if (isSaved != null)
                return Ok(new { sucess = 1 });
            return BadRequest();


        }


    }
}
