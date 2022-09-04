using Entities;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using Sheard.Command.Category;
using Sheard.Dto.Category;

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

        public async Task<Category> UpdateCategoryAsync(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                return await Table.Where(c => c.CategoryId == request.CategoryId)
                      .Select(c => new Category
                      {
                          CategoryId = c.CategoryId,
                          CategoryName = request.Dto.CategoryName,
                          Description = request.Dto.description,
                          ModifiDateTime = DateTime.Now
                      }).FirstOrDefaultAsync();
            }
            return null;
        }
    }
}
