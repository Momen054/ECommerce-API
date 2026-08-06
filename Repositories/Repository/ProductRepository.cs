using E_Commerce.Data;
using E_Commerce.Models;
using E_Commerce.Repositories.Repository_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(EcommerceDbContext context): base(context) { }

        public IQueryable<Product> AllProduct()
        {
            return _context.Products
                .Where(p => !p.Isdeleted == false);
        }
    }
}
