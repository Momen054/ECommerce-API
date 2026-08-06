using E_Commerce.Models;

namespace E_Commerce.Repositories.Repository_Interfaces
{
    public interface ICartRepository:IGenericRepository<Cart>
    {
        Task<CartItem?> GetCartItem(int cartId);
        Task Clear(int UserId);
    }
}
