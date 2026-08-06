using E_Commerce.Data;
using E_Commerce.DTOs.Cart;
using E_Commerce.DTOs.Categories;
using E_Commerce.Intefaces;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoriesController(ICategoryService _categoryService) : ControllerBase
    {
        
        [HttpGet("{Id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GetCategoriesDto>> GetById(int Id)
        {
            
            return Ok(await _categoryService.GetById(Id));
        }
        [HttpPost("")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(CategoriesDto dto)
        {
            await _categoryService.Create(dto);
            return Ok();
        }
        [HttpPut("")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put(CategoriesDto dto)
        {
            await _categoryService.Put(dto);
            return NoContent();
        }
        [HttpDelete]
        [Route("{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int Id)
        {
            await _categoryService.Delete(Id);
            return NoContent();
        }
    }
}
