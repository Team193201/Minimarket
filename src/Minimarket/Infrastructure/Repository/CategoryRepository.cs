using Entities;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> AnyCategoryIdAsync(Guid? id, CancellationToken cancellationToken)
        {
            return await TableNoTracking.AnyAsync(c => c.CategoryId == id, cancellationToken);
        }
    }
}
