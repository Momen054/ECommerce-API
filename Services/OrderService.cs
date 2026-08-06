using AutoMapper;
using E_Commerce.DTOs.Order;
using E_Commerce.Intefaces;
using E_Commerce.Models;
using E_Commerce.Repositories.UnitOfWork;


namespace E_Commerce.Services
{
    public class OrderService(IOrderItemService orderItemService
        , IMapper _mapper, IUnitOfWork _repository) : IOrderService
    {
        public async Task<IEnumerable<GetOrderDto>> Get()
        {
            var order = await _repository.GenericRepository<Order>().GetAll();
            if(order.Count()==0) throw new KeyNotFoundException("Orders not found");
            return _mapper.Map<IEnumerable<GetOrderDto>>(order);
        }
        public async Task<GetOrderDto> GetById(int id,int userId)
        {
            var order = await _repository.GenericRepository<Order>().GetById(id);
            if (order == null || order.UserId != userId) throw new KeyNotFoundException("Orders not found");
            return _mapper.Map<GetOrderDto>(order);
        }
        public async Task CreateOrder(OrderDto dto)
        {
            await using var transaction =
                 await _repository.BeginTransactionAsync();

            try
            {
               
                var cart = await _repository.Orders.GetCart(dto.UserId);
                if (cart == null)
                    throw new KeyNotFoundException("Cart not found");

                var cartItems = await _repository.Orders.GetCartItems(cart.Id);
                if (cartItems.Count() == 0) throw new KeyNotFoundException("Cart not found");
                decimal? total = 0;

                foreach (var item in cartItems)
                {
                    if (item.Quantity <= item.Product.Stock)
                    {
                        total += item.Product.Price * item.Quantity;
                        item.Product.Stock -= item.Quantity;
                    }
                    else throw new KeyNotFoundException("Product is not Aviliable");
                }

                Order order = new Order
                {
                    UserId = dto.UserId,
                    OrderDate = DateTime.UtcNow,
                    ShippingAddress = dto.ShippingAddress,
                    TotalPrice = total,
                    Status = (byte)OrderStatus.Pending
                };

                await _repository.GenericRepository<Order>().Create(order);
                _repository.Orders.RemoveCartItems(cartItems);
                await _repository.SaveChangesAsync();
                await orderItemService.CreateOrderItems(order, cartItems);
                await transaction.CommitAsync();
            }
            catch{
                await transaction.RollbackAsync();
                throw;
            }
        }
        
        public async Task Put(OrderDto dto)
        {
            if (dto == null) throw new Exception("Invalid Order");
            _repository.GenericRepository<Order>().Put(_mapper.Map<Order>(dto));
            await _repository.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var order = await _repository.GenericRepository<Order>().GetById(id);
            if (order == null) throw new KeyNotFoundException("Invalid Order");
            _repository.GenericRepository<Order>().Delete(id);
            await _repository.SaveChangesAsync();
        }
    }
}
