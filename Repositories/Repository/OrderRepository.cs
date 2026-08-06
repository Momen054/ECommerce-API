using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Repositories.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(EcommerceDbContext context) : base(context)
        {
        }
        public async Task<Cart?> GetCart(int userID)
        {
            return await
                _context.Carts
                .FirstOrDefaultAsync(c => c.UserId == userID);
        }

        public async Task<IEnumerable<CartItem>> GetCartItems(int cartId)
        {
            return await _context.CartItems
                    .Include(c => c.Product)
                    .Where(c => c.CartId == cartId)
                    .ToListAsync();
        }
        
        public void RemoveCartItems(IEnumerable<CartItem> obj)
            => _context.CartItems.RemoveRange(obj);
    }
}
