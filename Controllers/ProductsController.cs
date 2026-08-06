using E_Commerce.Data;
using E_Commerce.DTOs.Paginatio;
using E_Commerce.DTOs.Product;
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
    public class ProductsController(IProductService _productService) : ControllerBase
    {
       
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(PaginationDto pagination)
        {
            
            return Ok(await _productService.GetAllAsync(pagination));
        }
        [HttpGet]
        [Route("{Id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GetProductDto>> GetById(int id)
        {
            
            return Ok(await _productService.GetById(id));
        }
        [HttpPost]
        [Route("")]
        [Authorize(Roles = "Seller")]
        public async Task<ActionResult> Create(ProductDto dto)
        {
            await _productService.Create(dto);
            return Ok();
        }
        [HttpPut]
        [Route("")]
        [Authorize(Roles = "Seller")]
        public async Task<ActionResult> Put(ProductDto dto)
        {
            await _productService.Put(dto);
            return NoContent();
        }
        [HttpDelete]
        [Route("{Id}")]
        [Authorize(Roles = "Seller")]
        public async Task<ActionResult> Delete(int Id)
        {
            await _productService.Delete(Id);
            return NoContent();
        }
        [HttpGet]
        [Route("Query")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Product>> GetProducts(
        string? name,
        int? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        string? sortBy,
        bool ascending = true,
        int page = 1,
        int pageSize = 10)
        {
            var result = _productService.GetProducts(name,
            categoryId,
            minPrice,
            maxPrice,
            sortBy,
            ascending = true,
            page = 1,
            pageSize = 10);

            return Ok(result);
        }
        
    }
}
