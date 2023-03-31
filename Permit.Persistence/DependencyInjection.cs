using Permit.Application.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Permit.Application.Common.Persistence;
using Permit.Persistence.Repositories;

namespace Permit.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var environmentName = AppEnvironment.GetCurrentEnvironment();

            services.AddDbContextPool<PermitDbContext>((serviceProvider, options) =>
            {
                var connectionString = configuration.GetConnectionString("PermitConnectionString");
                options.UseSqlServer(connectionString);

                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<PermitDbContext>();

            return services;
        }
    }
}
