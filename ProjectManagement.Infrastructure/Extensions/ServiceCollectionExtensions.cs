using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Infrastructure.Interfaces;
using ProjectManagement.Infrastructure.Repositories;

namespace ProjectManagement.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Register your generic repository
            //services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register specific repositories, if needed
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
