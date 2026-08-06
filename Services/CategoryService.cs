using AutoMapper;
using E_Commerce.DTOs.Categories;
using E_Commerce.Intefaces;
using E_Commerce.Models;
using E_Commerce.Repositories.UnitOfWork;

namespace E_Commerce.Services
{
    public class CategoryService(IMapper _mapper, IUnitOfWork _repository) :ICategoryService
    {
        public async Task<GetCategoriesDto> GetById(int id)
        {
            var category = await _repository.GenericRepository<Category>().GetById(id);
            if (category == null || category.IsDeleted==false) throw new KeyNotFoundException("Category not found"); 
            return _mapper.Map<GetCategoriesDto>(category);
        }
        public async Task Create(CategoriesDto dto)
        {
            dto.IsDeleted = false;
            await _repository.GenericRepository<Category>().Create(_mapper.Map<Category>(dto));
            await _repository.SaveChangesAsync();
        }
        public async Task Put(CategoriesDto dto)
        {
            if(dto == null) throw new Exception("Invalid Category");
            _repository.GenericRepository<Category>().Put(_mapper.Map<Category>(dto));
            await _repository.SaveChangesAsync();
            
        }
        public async Task Delete(int id)
        {
            var category=await _repository.GenericRepository<Category>().GetById(id);
            if(category ==null) throw new KeyNotFoundException("Category not found");
            category.IsDeleted=true;
            await _repository.SaveChangesAsync();
        }
    }
}
