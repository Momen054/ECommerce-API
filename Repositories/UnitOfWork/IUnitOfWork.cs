using E_Commerce.Repositories.Repository_Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace E_Commerce.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;

        ICartRepository Carts { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        IUserRepository Users { get; }
        IJwtRepository Jwt { get; }
        IRefreshTokenRepository RefreshTokens { get; }
        Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();

    }
}
