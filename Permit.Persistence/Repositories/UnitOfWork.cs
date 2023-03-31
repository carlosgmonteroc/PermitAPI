using Permit.Application.Common.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Permit.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PermitDbContext context;
        private readonly IServiceProvider serviceProvider;
        private readonly Dictionary<Type, object> repositories;

        public UnitOfWork(PermitDbContext context, IServiceProvider serviceProvider)
        {
            this.context = context;
            this.serviceProvider = serviceProvider;
            repositories = new Dictionary<Type, object>();
        }

        public TCustomRepository? GetCustomRepository<TCustomRepository>() where TCustomRepository : class
        {
            var repositoryType = typeof(TCustomRepository);

            if (repositories.ContainsKey(repositoryType))
            {
                return repositories[repositoryType] as TCustomRepository;
            }

            var customRepositoryInstance = serviceProvider.GetRequiredService<TCustomRepository>();

            repositories.Add(repositoryType, customRepositoryInstance);

            return customRepositoryInstance;
        }

        public IRepository<TEntity>? GetRepositoryFor<TEntity>() where TEntity : class
        {
            var repositoryType = typeof(IRepository<TEntity>);

            if (repositories.ContainsKey(repositoryType))
            {
                return repositories[repositoryType] as IRepository<TEntity>;
            }

            var repositoryInstance = new Repository<TEntity>(context);

            repositories.Add(repositoryType, repositoryInstance);

            return repositoryInstance;
        }

        public async Task<int> SaveChangesAsync()
        {
            var entriesWrittenCount = await context.SaveChangesAsync();
            return entriesWrittenCount;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
