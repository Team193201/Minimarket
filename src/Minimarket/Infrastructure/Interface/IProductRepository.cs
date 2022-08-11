using Entities;

namespace Infrastructure.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetProductsAsync(int take, int skip, CancellationToken cancellationToken);
    }
}
