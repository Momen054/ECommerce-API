using E_Commerce.Models;

namespace E_Commerce.Intefaces
{
    public interface IOrderItemService
    {
        Task CreateOrderItems(Order order, IEnumerable<CartItem> cartItems);
    }
}
