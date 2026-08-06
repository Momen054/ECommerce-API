using E_Commerce.DTOs.Auth;
using E_Commerce.DTOs.User;
using E_Commerce.Models;

namespace E_Commerce.Intefaces
{
    public interface IJwtService 
    {
        Task<AuthResponseDto> AuthenticatUser(UserPermissionDto dto);
        Task Register(UserDto dto);
        string GenerateAccessToken(User user);
        RefreshToken GenerateRefreshToken(int userId);
    }
}
