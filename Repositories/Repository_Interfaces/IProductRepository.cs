using E_Commerce.Models;

namespace E_Commerce.Repositories.Repository_Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable<Product> AllProduct();
    }
}
