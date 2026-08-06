using E_Commerce.Models;

namespace E_Commerce.Repositories.Repository_Interfaces
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        Task<Cart?> GetCart(int userID);
        Task<IEnumerable<CartItem>> GetCartItems(int cartId);
        void RemoveCartItems(IEnumerable<CartItem> obj);
    }
}
