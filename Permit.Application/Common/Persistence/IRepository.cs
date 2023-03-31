using System.Linq.Expressions;

namespace Permit.Application.Common.Persistence
{
    public interface IRepository<TEntity> where TEntity: class
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? filter = null, string[]? includeProperties = null);
    }
}
