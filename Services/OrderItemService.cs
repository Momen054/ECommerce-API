using E_Commerce.Intefaces;
using E_Commerce.Models;
using E_Commerce.Repositories.UnitOfWork;


namespace E_Commerce.Services
{
    public class OrderItemService(IUnitOfWork _repository):IOrderItemService
    {
        public async Task CreateOrderItems(Order order, IEnumerable<CartItem> cartItems)
        {
            if(cartItems==null) throw new KeyNotFoundException("CartItem not found");
            foreach (var item in cartItems)
            {
                OrderItem orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Product.Price
                };

                await _repository.GenericRepository<OrderItem>().Create(orderItem);
            }

            await _repository.SaveChangesAsync();
        }
    }
}
