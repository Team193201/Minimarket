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

        public async Task<bool> AnyCategoryNameAsync(string name, CancellationToken cancellationToken)
        {
            return await TableNoTracking.AnyAsync(c => c.CategoryName == name, cancellationToken);
        }

        public async Task<Category> GetCategoryByIdAsync(Guid? id, CancellationToken cancellationToken)
        {
            var category = await Table.FirstOrDefaultAsync(c => c.CategoryId == id, cancellationToken);
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Guid? categoryId, CancellationToken cancellationToken)
        {
            return await Table.Where(c => c.CategoryId == categoryId).FirstOrDefaultAsync();
        }
    }
}
