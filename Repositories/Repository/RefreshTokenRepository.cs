using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Repositories.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories.Repository
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(EcommerceDbContext context) : base(context)
        {
        }

        public async Task<RefreshToken?> GetToken(string refreshToken)
            => await _context.RefreshTokens
                .Include(r => r.User)
                .ThenInclude(u => u.userRoles)
                .ThenInclude(ur => ur.Role)
                 .FirstOrDefaultAsync(r => r.Token == refreshToken);
    }
}
