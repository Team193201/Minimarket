using Entities.Interface;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class, IEntity
    {
        private readonly AppDbContext _appDbContext;

        private readonly DbSet<T> entity;

        public IQueryable<T> Table => entity;
        public IQueryable<T> TableNoTracking => entity.AsNoTracking();

        public Repository(AppDbContext appDbContext)
        { 
            _appDbContext = appDbContext;
            entity = _appDbContext.Set<T>();
        }

       
        #region Add
        public void AddEntity(T model)
        {
            entity.Add(model);
        }

        public void AddRangeEntities(IEnumerable<T> models)
        {
            entity.AddRange(models);
        }

        public async Task AddAsyncEntity(T model, CancellationToken cancellationToken)
        {
            await entity.AddAsync(model, cancellationToken);
        }

        public async Task AddRangeAsyncEntities(IEnumerable<T> models, CancellationToken cancellationToken)
        {
            await entity.AddRangeAsync(models, cancellationToken);
        }

        #endregion

        #region Update
        public void UpdateEntity(T model)
        {
            entity.Update(model);
        }
        public void UpdateRangeEntities(IEnumerable<T> models)
        {
            entity.UpdateRange(models);
        }

        #endregion

        #region Delete
        public void DeleteEntity(T model)
        {
            entity.Remove(model);
        }
        public void DeleteRangeEntities(IEnumerable<T> models)
        {
            entity.RemoveRange(models);
        }
        #endregion



        // rep role
        // rep product

        // UnitOfWork save role , product
    }
}
