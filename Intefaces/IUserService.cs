using E_Commerce.DTOs.User;
using E_Commerce.Models;

namespace E_Commerce.Intefaces
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserDto>> Get();
        Task<GetUserDto> GetById(int id);
        Task Put(UserDto user);
        Task Delete(int id);
    }
}
