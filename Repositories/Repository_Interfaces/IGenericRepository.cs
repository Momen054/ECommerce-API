using E_Commerce.DTOs.Cart;
using E_Commerce.DTOs.Order;
using E_Commerce.DTOs.Role;

namespace E_Commerce.Repositories.Repository_Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        Task Create(T entity);
        void Put(T entity);
        void Delete(int id);
    }
}
