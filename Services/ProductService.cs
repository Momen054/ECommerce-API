using AutoMapper;
using E_Commerce.DTOs.Paginatio;
using E_Commerce.DTOs.Product;
using E_Commerce.Intefaces;
using E_Commerce.Models;
using E_Commerce.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Services
{
    public class ProductService(IMapper _mapper, IUnitOfWork _repository) : IProductService
    {
 
        public async Task<PaginatedResponse<GetProductDto>> GetAllAsync(PaginationDto pagination)
        {
            var query = _repository.Products.AllProduct();

            var totalCount = await query.CountAsync();
            if (totalCount == 0) throw new KeyNotFoundException("Products not found");

            var products = await query
                .OrderBy(p => p.Id)
                .Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();


            return new PaginatedResponse<GetProductDto>
            {
                Page = pagination.Page,
                PageSize = pagination.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((double)totalCount / pagination.PageSize),
                Data = _mapper.Map<List<GetProductDto>>(products)
            };
        }
        public async Task<GetProductDto> GetById(int id)
        {
            var product = await _repository.GenericRepository<Product>().GetById(id);
            if (product == null) throw new KeyNotFoundException("Product not found");
            return _mapper.Map<GetProductDto>(product);
        }
        public async Task Create(ProductDto dto)
        { 
            dto.CreatedAt = DateTime.Now;
            dto.Isdeleted = false;
            await _repository.GenericRepository<Product>().Create(_mapper.Map<Product>(dto));
            await _repository.SaveChangesAsync();
            
        }
        public async Task Put(ProductDto dto)
        {
            
            if (dto == null) throw new Exception("Invalid Product");
            dto.UpdatedAt= DateTime.Now;
            _repository.GenericRepository<Product>().Put(_mapper.Map<Product>(dto));
            await _repository.SaveChangesAsync();
            
        }
        public async Task Delete(int id)
        {
            var product = await _repository.GenericRepository<Product>().GetById(id);
            if (product == null) throw new KeyNotFoundException("Product not found");
            product.Isdeleted = true;
            await _repository.SaveChangesAsync();
        }
        public IEnumerable<Product> GetProducts(
        string? name,
        int? categoryId,
        decimal? minPrice,
        decimal? maxPrice,
        string? sortBy,
        bool ascending = true,
        int page = 1,
        int pageSize = 10)
        {
            var query = _repository.Products.AllProduct();
            // Search
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }
            // Filter
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }
            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice);
            }
            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice);
            }
            // Sorting
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "price":
                        query = ascending
                            ? query.OrderBy(p => p.Price)
                            : query.OrderByDescending(p => p.Price);
                        break;

                    case "name":
                        query = ascending
                            ? query.OrderBy(p => p.Name)
                            : query.OrderByDescending(p => p.Name);
                        break;
                }
            }

            // Pagination
            var result = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return result;
        }
    }
}
