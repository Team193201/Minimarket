using Entities.Interface;
using Infrastructure.Interface;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class, IEntity
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
