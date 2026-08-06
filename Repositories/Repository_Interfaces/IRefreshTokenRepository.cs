using E_Commerce.Models;

namespace E_Commerce.Repositories.Repository_Interfaces
{
    public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
    {
        Task<RefreshToken?> GetToken(string refreshToken);
    }
}
