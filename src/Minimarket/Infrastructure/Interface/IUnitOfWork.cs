using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public  interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; set; }
        IUserReository UserReository { get; set; }

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
