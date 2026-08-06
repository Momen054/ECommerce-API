using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Repositories.Repository;
using E_Commerce.Repositories.Repository_Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;

namespace E_Commerce.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceDbContext _context;
        private Hashtable? _repositories;

        public ICartRepository Carts { get; }
        public IProductRepository Products { get; }
        public IOrderRepository Orders { get; }
        public IUserRepository Users { get; }
        public IJwtRepository Jwt { get; }
        public IRefreshTokenRepository RefreshTokens { get; }

        public UnitOfWork(EcommerceDbContext context)
        {
            _context = context;

            Carts = new CartRepository(_context);
            Products = new ProductRepository(_context); 
            Orders = new OrderRepository(_context);
            Users = new UserRepository(_context);
            Jwt = new JwtRepository(_context);
            RefreshTokens = new RefreshTokenRepository(_context);
        }

        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
            =>await _context.Database.BeginTransactionAsync();
    }
}
