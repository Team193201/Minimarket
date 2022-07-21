using Entities.Model;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserReository : Repository<User>, IUserReository
    {
        public UserReository(AppDbContext appDbContext)
            : base(appDbContext)
        {

        }

        public async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            //    Table.Where(w => w.Id == id).Select(s => new User 
            //    {
            //      Id=s.Id,
            //      Email=s.Email,   
            //    });

            var user = await Table.Where(f => f.Id == id).FirstOrDefaultAsync(cancellationToken);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsersByNameAsync(string name, CancellationToken cancellationToken)
        {
            var users = await TableNoTracking.Where(w => w.UserName == name).ToListAsync(cancellationToken);

            return users;
        }
    }
}
