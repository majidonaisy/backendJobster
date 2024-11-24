using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public AuthService _authService { get; set; }
        public TokenService _tokenService { get; set; }
        public TestController(AuthService authService, TokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok("Hello World");
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] DTOs.RegisterRequest request)
        {

            var result = await _authService.RegisterUser(request);
            if (!result.Success) { return Conflict(result.Message); }
            var token = _tokenService.GenerateToken(result.User);
            return Ok(new
            {
                Token = token,
                Message = "User registered and logged in successfully"
            });
        }


    }
}
