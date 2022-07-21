using Entities;

namespace Infrastructure.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void GetCategoryByDatetime();
    }
}
