using E_Commerce.Data;
using E_Commerce.DTOs.User;
using E_Commerce.Models;
using E_Commerce.Repositories.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories.Repository
{
    public class JwtRepository:GenericRepository<User>,IJwtRepository
    {
        public JwtRepository(EcommerceDbContext context)
            :base(context) { }

        public async Task<User?> GetUser(UserPermissionDto dto)
            =>await _context.Users
                .Include(r => r.RefreshTokens)
                .Include(u => u.userRoles)
                .ThenInclude(u => u.Role)
                .FirstOrDefaultAsync(u => u.IsDeleted == false && u.UserName == dto.UserName);

        public async Task AddRefreshToken(RefreshToken token)
            => await _context.RefreshTokens.AddAsync(token);
    }
}
