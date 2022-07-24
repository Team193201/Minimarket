using Entities;

namespace Infrastructure.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
         Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name, CancellationToken cancellationToken);
    }
}
