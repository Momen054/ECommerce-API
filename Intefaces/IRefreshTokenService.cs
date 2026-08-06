using E_Commerce.DTOs.Auth;
using E_Commerce.Models;

namespace E_Commerce.Intefaces
{
    public interface IRefreshTokenService
    {
        Task<AuthResponseDto> RefreshTokenAsync(string refreshToken);
        Task Revoked(string refreshToken);
    }
}
