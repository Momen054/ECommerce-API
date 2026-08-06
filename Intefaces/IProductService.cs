using E_Commerce.DTOs.Paginatio;
using E_Commerce.DTOs.Product;
using E_Commerce.Models;

namespace E_Commerce.Intefaces
{
    public interface IProductService
    {
        Task<PaginatedResponse<GetProductDto>> GetAllAsync(PaginationDto pagination);
        Task<GetProductDto> GetById(int id);
        Task Create(ProductDto dto);
        Task Put(ProductDto dto);
        Task Delete(int id);
        IEnumerable<Product> GetProducts(
        string? name,
        int? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        string? sortBy,
        bool ascending = true,
        int page = 1,
        int pageSize = 10);
    }
}
