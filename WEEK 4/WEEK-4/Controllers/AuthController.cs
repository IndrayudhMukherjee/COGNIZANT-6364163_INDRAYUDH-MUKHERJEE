using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MyWebApi.Services;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpGet("token")]
        [AllowAnonymous]
        public IActionResult GetToken()
        {
            var token = _jwtService.GenerateToken(1, "Admin");
            return Ok(new { token });
        }
    }
}
