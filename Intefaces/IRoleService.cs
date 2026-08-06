using E_Commerce.DTOs.Role;
using E_Commerce.Models;

namespace E_Commerce.Intefaces
{
    public interface IRoleService
    {
        Task<GetRoleDto> Get(int id);
        Task Create(RoleDto dto);
        Task Put(RoleDto dto);
        Task Delete(int Id);
    }
}
