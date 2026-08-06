using E_Commerce.Data;
using E_Commerce.DTOs.Review;
using E_Commerce.Intefaces;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Customer")]
    public class ReviewsController(IReviewService _reviewService, IHttpContextAccessor Context) : ControllerBase
    {
        int userId = int.Parse(Context.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        [HttpGet]
        [Route("{Id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GetReviewDto>> GetById(int id)
        {
            
            return Ok(await _reviewService.GetById(id));
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Create(ReviewDto dto)
        {
            await _reviewService.Create(dto);
            return Ok();
        }
        [HttpPut]
        [Route("")]
        public async Task<ActionResult> Put(ReviewDto dto)
        {   
            if (dto.UserId == userId)
            {
                await _reviewService.Put(dto);
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("")]
        public async Task<ActionResult> Delete(int id)
        {      
             await _reviewService.Delete(id,userId);
             return NoContent();
        }
    }
}
