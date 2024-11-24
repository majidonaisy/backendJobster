using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthService _authService { get; set; }
        public TokenService _tokenService { get; set; }
        public AuthController(AuthService authService, TokenService tokenService)
        {
            _authService = authService;   
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] DTOs.RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }
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
