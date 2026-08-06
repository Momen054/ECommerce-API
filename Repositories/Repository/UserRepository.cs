using E_Commerce.Data;
using E_Commerce.DTOs.User;
using E_Commerce.Models;
using E_Commerce.Repositories.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories.Repository
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(EcommerceDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsers()
            => await _context.Users.Where(p => p.IsDeleted == false).ToListAsync();
    }
}
