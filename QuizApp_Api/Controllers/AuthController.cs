using Microsoft.AspNetCore.Mvc;
using QuizApp_BL.DTOs;
using QuizApp_BL.Services.AuthService;

namespace QuizApp_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegistrationDTO registrationDTO)
        {
            await _authService.RegisterAsync(registrationDTO);
            return Ok();
        }
       
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDTO loginDTO)
        {
            var result = await _authService.LoginAsync(loginDTO);
            return Ok(result);
        }
    }
}
