using Entities;

namespace Infrastructure.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
         Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name, CancellationToken cancellationToken);
    }
}
