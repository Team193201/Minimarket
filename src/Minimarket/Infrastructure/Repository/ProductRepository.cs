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

        public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Table.FirstOrDefaultAsync(p => p.ProductId == id, cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await TableNoTracking.Where(p => p.ProductName == name).ToListAsync(cancellationToken);
        }
    }
}
