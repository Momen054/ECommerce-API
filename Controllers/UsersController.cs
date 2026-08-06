using E_Commerce.Data;
using E_Commerce.DTOs.User;
using E_Commerce.Intefaces;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsersController(IUserService _userService, IHttpContextAccessor Context) : ControllerBase
    {
        int userId = int.Parse(Context.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        [HttpGet("")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> Get()
        {
            var users =await _userService.Get();
            return Ok(users);
        }
        [HttpGet("Id")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<GetUserDto>> GetById()
        {
            var user =await _userService.GetById(userId);
            return Ok(user);
        }
        [HttpPut("")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> Put(UserDto dto)
        {
            if (dto.Id == userId)
            {
                await _userService.Put(dto);
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> Delete() 
        {   
            await _userService.Delete(userId);
            return NoContent();
        }
    }
}
