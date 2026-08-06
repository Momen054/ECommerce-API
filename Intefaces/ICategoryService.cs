using E_Commerce.DTOs.Categories;
using E_Commerce.Models;

namespace E_Commerce.Intefaces
{
    public interface ICategoryService
    {
        Task<GetCategoriesDto> GetById(int id);
        Task Create(CategoriesDto dto);
        Task Put(CategoriesDto dto);
        Task Delete(int Id);
    }
}
