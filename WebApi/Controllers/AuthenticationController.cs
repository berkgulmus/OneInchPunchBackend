using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Repositories.AuthenticationRepository;
using BusinessLayer.Requests;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationController(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var response = await _authenticationRepository.Login(loginRequest);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
