using AutoMapper;
using E_Commerce.DTOs.Cart;
using E_Commerce.Intefaces;
using E_Commerce.Models;
using E_Commerce.Repositories.UnitOfWork;

namespace E_Commerce.Services
{
    public class CartService(IMapper _mapper
        , IUnitOfWork _repository) :ICartService
    {
        
        public async Task<GetCartDto> GetById(int id,int userId)
        {
            var cart = await _repository.GenericRepository<Cart>().GetById(id);
            if (cart == null || cart.UserId != userId) throw new KeyNotFoundException("Cart not found");
            return _mapper.Map<GetCartDto>(cart);
            
        }

        public async Task AddToCart(int id,int userId, int productId, int quantity)
        {
            var cart = await _repository.GenericRepository<Cart>().GetById(id);

            if (cart == null || cart.UserId != userId)
            {
                cart = new Cart
                {
                    UserId = userId,
                    CreatedAt = DateTime.UtcNow
                };

                await _repository.GenericRepository<Cart>().Create(cart);
                await _repository.SaveChangesAsync();
                
                CartItem item = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = quantity
                };
                await _repository.GenericRepository<CartItem>().Create(item);
            }
            else
            {
                var cartItem = await _repository.Carts.GetCartItem(cart.Id);
                cartItem.Quantity += quantity;
                _repository.GenericRepository<CartItem>().Put(cartItem);

            }

            await _repository.SaveChangesAsync();
        }

        public async Task Put(CartDto dto)
        {
            if (dto == null) throw new Exception("Invalid Cart");
            _repository.GenericRepository<Cart>().Put(_mapper.Map<Cart>(dto));
            await _repository.SaveChangesAsync();
            
        }
        
        public async Task Delete(int id,int userId)
        {
            var cart = await _repository.GenericRepository<Cart>().GetById(id);
            if (cart == null || cart.UserId != userId) throw new KeyNotFoundException("Invalid Cart");
            _repository.GenericRepository<Cart>().Delete(id);
            await _repository.SaveChangesAsync();
        }
        
        public async Task Clear(int UserId)
        {

            await _repository.Carts.Clear(UserId);
        }
        
    }
}
