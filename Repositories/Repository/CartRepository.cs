using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Repositories.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories.Repository
{
    public class CartRepository : GenericRepository<Cart> ,ICartRepository
    {
        
        public CartRepository(EcommerceDbContext context) : base(context)
        {
        }

        public async Task<CartItem?> GetCartItem(int cartId)
            => await _context.CartItems.FirstOrDefaultAsync(x => x.CartId == cartId);

        public async Task Clear(int UserId)
        {
            await _context.Carts
                    .Where(x => x.UserId == UserId)
                    .ExecuteDeleteAsync();
        }
    }
}
