using Entities;

namespace Infrastructure.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> AnyCategoryIdAsync(Guid? id, CancellationToken cancellationToken);
        Task<bool> AnyCategoryNameAsync(string name, CancellationToken cancellationToken);
        Task<IEnumerable<Category>> GetCategoreisAsync(int take, int skip, CancellationToken cancellationToken);
        Task<Category> GetCategoryByIdAsync(Guid? id, CancellationToken cancellationToken);
        Task<Category> GetCategoryByNameAsync(string name, CancellationToken cancellationToken);
        Task<Guid> GetCategoryIdByNameAsync(string name, CancellationToken cancellationToken);
    }
}
