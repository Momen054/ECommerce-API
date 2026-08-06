using E_Commerce.DTOs.Cart;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Intefaces
{
    public interface ICartService
    {
        Task<GetCartDto> GetById(int id,int userId);
        Task AddToCart(int id, int userId, int productId, int quantity);
        Task Put(CartDto dto);
        Task Delete(int id,int userId);
        Task Clear(int userId);
    }
}
