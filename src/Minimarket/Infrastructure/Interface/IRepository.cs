using Entities.Interface;

namespace Infrastructure.Interface
{
    public interface IRepository<T>
        where T : class, IEntity
    {
        void AddEntity(T model);
        void AddRangeEntities(IEnumerable<T> models);
        Task AddAsyncEntity(T model, CancellationToken cancellationToken);
        Task AddRangeAsyncEntities(IEnumerable<T> models, CancellationToken cancellationToken);
    }
}
