using E_Commerce.DTOs.User;
using E_Commerce.Models;

namespace E_Commerce.Repositories.Repository_Interfaces
{
    public interface IJwtRepository : IGenericRepository<User>
    {
        Task<User?> GetUser(UserPermissionDto dto);
        Task AddRefreshToken(RefreshToken token);
    }
}
