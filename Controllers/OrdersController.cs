using E_Commerce.Data;
using E_Commerce.DTOs.Order;
using E_Commerce.Intefaces;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController(IOrderService _orderService, IHttpContextAccessor Context) : ControllerBase
    {
        int userId = int.Parse(Context.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        [HttpGet("")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<GetOrderDto>>> Get()
        {  
            
            return Ok(await _orderService.Get());
        }
        [HttpGet("{Id}")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<GetOrderDto>> GetById(int id)
        {

            return Ok(await _orderService.GetById(id, userId));
        }
        [HttpPost("")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> CreateOrder(OrderDto dto)
        {
            await _orderService.CreateOrder(dto);
            return Ok();
        }
        [HttpPut("{Id}")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> Put(OrderDto dto)
        {
            if (dto.UserId == userId)
            {
                await _orderService.Put(dto);
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            await _orderService.Delete(id);
            return NoContent();
        }
    }
}
