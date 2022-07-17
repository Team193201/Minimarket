using Entities.Model;

namespace Infrastructure.Interface
{
    public interface IUserReository : IRepository<User>
    {
        void AddUser(User model);
    }
}
