using Entities;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {

        }

        public async Task<Product> GetProductAsync(Guid? categoryId, Guid productId, CancellationToken cancellationToken)
        {
            return await TableNoTracking.FirstOrDefaultAsync(p => p.CategoryId == categoryId && p.ProductId == productId, cancellationToken);
        }

        public async Task<Product> GetProductAsync(Guid? categoryId, string productName, CancellationToken cancellationToken)
        {
            return await TableNoTracking.FirstOrDefaultAsync(p => p.CategoryId == categoryId && p.ProductName == productName, cancellationToken);
        }

        public async Task<Product> GetProductAsync(Guid? productId, CancellationToken cancellationToken)
        {
            return await TableNoTracking.FirstOrDefaultAsync(p => p.ProductId == productId, cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await TableNoTracking.Where(p => p.ProductName.Contains(name)).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int take, int skip, CancellationToken cancellationToken)
        {
            return await TableNoTracking.Skip(skip).Take(take is 0 ? 10 : take).ToListAsync(cancellationToken);
        }


    }
}
