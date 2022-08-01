namespace Infrastructure.Interface
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; set; }
        IUserReository UserReository { get; set; }
        IProductRepository ProductRepository { get; set; }
        IRoleRepository RoleRepository { get; set; }


        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
