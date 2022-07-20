using Entities.Model;
using Infrastructure.Interface;

namespace Infrastructure.Repository
{
    public class UserReository : Repository<User>, IUserReository
    {
        public UserReository(AppDbContext appDbContext)
            : base(appDbContext)
        {

        }

        public void AddUser(User model)
        {
            AddEntity(model);
        }
    }

    //public class Commandhandler
    //{
    //    IUserReository UserReository;
    //    public Commandhandler(IUserReository userReository)
    //    {
    //        UserReository = userReository;
    //    }

    //    public void Handel(Command command)
    //    {
    //        //command

    //        UserReository.AddUser();
    //    }
    //}
}
