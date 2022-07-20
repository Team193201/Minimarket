using Entities.Interface;

namespace Infrastructure.Interface
{
    public interface IRepository<T>
        where T : class, IEntity
    {
    }
}
