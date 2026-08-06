using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Repositories.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly EcommerceDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(EcommerceDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task Create(T entity)
            => await _dbSet.AddAsync(entity);

        public void Delete(int id)
        {
            var obj = _dbSet.Find(id);
            if (obj != null) 
                _dbSet.Remove(obj);
        }

        public async Task<IEnumerable<T>> GetAll()
            => await _dbSet.ToListAsync();

        public async Task<T?> GetById(int id)
            =>await _dbSet.FindAsync(id);

        public void Put(T entity)
            => _dbSet.Update(entity);
    
    }
}
