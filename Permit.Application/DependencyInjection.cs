using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Permit.Application.PermitTypes;
using Permit.Application.Permits;
using System.Reflection;

namespace Permit.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration, bool isEnvDevelopment)
        {
            services.AddAutoMapper(Assembly.Load("Permit.Application"));
            services.AddScoped<IPermitTypeService, PermitTypeService>();
            services.AddScoped<IPermitService, PermitService>();
            services.AddTransient(typeof(Lazy<>), typeof(LazilyResolved<>));
            return services;
        }

        public static IApplicationBuilder InitializeApplicationCaches(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                List<Task> tasks = new();

                var permitTypeService = scope.ServiceProvider.GetService<IPermitTypeService>();
                tasks.Add(permitTypeService.Get());

                Task.WhenAll(tasks).Wait();
            }

            return app;
        }

        private class LazilyResolved<T> : Lazy<T>
        {
            public LazilyResolved(IServiceProvider serviceProvider)
                : base(serviceProvider.GetRequiredService<T>)
            {
            }
        }
    }
}
