using E_Commerce.DTOs.Auth;
using E_Commerce.DTOs.User;
using E_Commerce.Intefaces;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController(IJwtService _jwtService,IRefreshTokenService _service):ControllerBase
    {
        [HttpPost("LogIn")]
        public async Task<ActionResult<AuthResponseDto>> LogIn(UserPermissionDto dto)
        {

            return Ok(await _jwtService.AuthenticatUser(dto));
        }
        [HttpPost("signIn")]
        public async Task<ActionResult> SignIn(UserDto dto) {
            await _jwtService.Register(dto);
            return Ok();
        }
        [HttpPost("RefreshToken")]
        public async Task<ActionResult<AuthResponseDto>> RefreshTokenAsync(string refreshToken)
        {
            return Ok(await _service.RefreshTokenAsync(refreshToken));
        }
        [HttpPost("RevokeToken")]
        public async Task<IActionResult> Revoked(string refreshToken)
        {
            await _service.Revoked(refreshToken);
            return Ok();
        }
    }
}
