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

        public async Task<Product> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await TableNoTracking.FirstOrDefaultAsync(p => p.ProductId == id, cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await TableNoTracking.Where(p => p.ProductName == name).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int take, int skip, CancellationToken cancellationToken)
        {
            return await TableNoTracking.Skip(skip).Take(take is 0 ? 10 : take).ToListAsync(cancellationToken);
        }
    }
}
