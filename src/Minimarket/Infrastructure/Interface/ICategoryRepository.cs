using Entities;

namespace Infrastructure.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> AnyCategoryIdAsync(Guid? id, CancellationToken cancellationToken);
        Task <bool>AnyCategoryNameAsync(string name, CancellationToken cancellationToken);
    }
}
