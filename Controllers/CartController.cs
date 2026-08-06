using E_Commerce.Data;
using E_Commerce.DTOs.Cart;
using E_Commerce.Intefaces;
using E_Commerce.Mapping;
using AutoMapper;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Customer")]
    public class CartController(ICartService cartService, IHttpContextAccessor Context) : ControllerBase
    {
        int userId = int.Parse(Context.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult<GetCartDto>> GetById(int id)
        {
            
            return Ok(await cartService.GetById(id, userId));
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult> AddToCart(int id,int productId, int quantity)
        {
            await cartService.AddToCart(id, userId, productId, quantity);
            return Ok();
        }
        [HttpPut]
        [Route("")]
        public async Task<ActionResult> Put(CartDto dto)
        {
            if (dto.UserId == userId)
            {
                await cartService.Put(dto);
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await cartService.Delete(id, userId);
            return NoContent();
        }
        [HttpDelete]
        [Route("clear")]
        public async Task<IActionResult>  Clear()
        {
            await cartService.Clear(userId);
            return NoContent();
        }
    }
}
