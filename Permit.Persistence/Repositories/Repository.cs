using Microsoft.EntityFrameworkCore;
using Permit.Application.Common.Persistence;
using System.Linq.Expressions;

namespace Permit.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly PermitDbContext context;
        private readonly DbSet<TEntity> dbSet;
        public Repository(PermitDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            var result = dbSet.Add(entity);
            return result.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            return dbSet.Update(entity).Entity;
        }

        public TEntity Delete(TEntity entity)
        {
            return dbSet.Remove(entity).Entity;
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? filter = null)
        {
            IQueryable<TEntity> query = Filter(dbSet, filter);

            return await query.ToListAsync();
        }
        private IQueryable<TEntity> Filter(IQueryable<TEntity> query, Expression<Func<TEntity, bool>>? filter = null)
        {
            if (filter != null)
                query = query.Where(filter);

            return query;
        }
    }
}
