using Entities;

namespace Infrastructure.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductAsync(Guid categoryId, Guid productId, CancellationToken cancellationToken);
        Task<Product> GetProductAsync(Guid categoryId, string productName, CancellationToken cancellationToken);
        Task<Product> GetProductAsync(Guid productId, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetProductsAsync(int take, int skip, CancellationToken cancellationToken);
    }
}
