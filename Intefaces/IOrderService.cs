using E_Commerce.DTOs.Order;
using E_Commerce.Models;

namespace E_Commerce.Intefaces
{
    public interface IOrderService
    {
        Task<IEnumerable<GetOrderDto>> Get();
        Task<GetOrderDto> GetById(int id,int userId);
        Task CreateOrder(OrderDto dto);
        Task Put(OrderDto dto);
        Task Delete(int id);
    }
}
