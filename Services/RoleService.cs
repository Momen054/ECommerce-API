using AutoMapper;
using E_Commerce.DTOs.Role;
using E_Commerce.Intefaces;
using E_Commerce.Models;
using E_Commerce.Repositories.UnitOfWork;
namespace E_Commerce.Services
{
    public class RoleService(IMapper _mapper,IUnitOfWork _repository):IRoleService
    {
        public async Task<GetRoleDto> Get(int id)
        {
            var role = await _repository.GenericRepository<Role>().GetById(id);
            if (role == null) throw new KeyNotFoundException("Role not found");
            return _mapper.Map<GetRoleDto>(role);
        }
        public async Task Create(RoleDto dto)
        {
            if(dto == null) throw new Exception("Invalid Role");
            await _repository.GenericRepository<Role>().Create(_mapper.Map<Role>(dto));
            await _repository.SaveChangesAsync();
        }
        public async Task Put(RoleDto dto)
        {
            if (dto == null) throw new Exception("Invalid Role");
            _repository.GenericRepository<Role>().Put(_mapper.Map<Role>(dto));
            await _repository.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var role = await _repository.GenericRepository<Role>().GetById(id);
            if (role == null) throw new KeyNotFoundException("Invalid Role");
            _repository.GenericRepository<Role>().Delete(id);
            await _repository.SaveChangesAsync();
        }
    }
        
}

