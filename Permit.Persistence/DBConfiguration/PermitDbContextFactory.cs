using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Permit.Application.Common;

namespace Permit.Persistence
{
    public class PermitDbContextFactory : DesignTimeDbContextFactoryBase<PermitDbContext>
    {
        protected override PermitDbContext CreateNewInstance(DbContextOptionsBuilder<PermitDbContext> builder)
        {
            return new PermitDbContext(builder.Options);
        }
    }

    public abstract class DesignTimeDbContextFactoryBase<TContext> :
            IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private const string ConnectionStringName = "PermitConnectionString";

        public TContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("", Path.DirectorySeparatorChar);
            return Create(basePath, AppEnvironment.GetCurrentEnvironment());
        }

        protected abstract TContext CreateNewInstance(DbContextOptionsBuilder<TContext> builder);

        private TContext Create(string basePath, string environmentName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString(ConnectionStringName);

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            return CreateNewInstance(GetBuilder(connectionString));
        }

        protected virtual DbContextOptionsBuilder<TContext> GetBuilder(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<TContext>();
            builder.UseSqlServer(connectionString);

            return builder;
        }
    }
}
