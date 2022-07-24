using Infrastructure.Interface;
using Infrastructure.Repository;

namespace Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private AppDbContext AppDbContext { get; set; }

        public ICategoryRepository CategoryRepository { get; set; }
        public IUserReository UserReository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }


        public UnitOfWork(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
            CategoryRepository = new CategoryRepository(AppDbContext);
            UserReository = new UserReository(AppDbContext);
            ProductRepository = new ProductRepository(AppDbContext);
            RoleRepository = new RoleRepository(AppDbContext);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await AppDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
