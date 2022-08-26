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

        /// <summary>
        /// we want to track data with ef core
        /// </summary>
        public IQueryable<T> Table => entity;

        /// <summary>
        /// we didnet want to track data with ef core
        /// </summary>
        public IQueryable<T> TableNoTracking => entity.AsNoTracking();

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            entity = _appDbContext.Set<T>();
        }


        #region Add
        /// <summary>
        /// add entity
        /// </summary>
        /// <param name="model"></param>
        public void AddEntity(T model)
        {
            entity.Add(model);
        }

        /// <summary>
        /// add list of entity
        /// </summary>
        /// <param name="models"></param>
        public void AddRangeEntities(IEnumerable<T> models)
        {
            entity.AddRange(models);
        }

        /// <summary>
        /// add async entity 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task AddEntityAsync(T model, CancellationToken cancellationToken)
        {
            await entity.AddAsync(model, cancellationToken);
        }

        /// <summary>
        /// add async list of entity
        /// </summary>
        /// <param name="models"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task AddRangeEntitiesAsync(IEnumerable<T> models, CancellationToken cancellationToken)
        {
            await entity.AddRangeAsync(models, cancellationToken);
        }

        #endregion

        #region Update

        /// <summary>
        /// update entity
        /// </summary>
        /// <param name="model"></param>
        public void UpdateEntity(T model)
        {
            entity.Update(model);
        }
        public void UpdateRangeEntities(IEnumerable<T> models)
        {
            entity.UpdateRange(models);
        }

        #endregion

        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="model"></param>
        #region Delete
        public void DeleteEntity(T model)
        {
            entity.Remove(model);
        }

        /// <summary>
        /// delete list of entity
        /// </summary>
        /// <param name="models"></param>
        public void DeleteRangeEntities(IEnumerable<T> models)
        {
            entity.RemoveRange(models);
        }
        #endregion
    }
}
