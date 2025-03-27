using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Application.Interfaces;
using ProjectManagement.Application.Mapper;
using ProjectManagement.Application.UseCases.UserDetails.Query;
using ProjectManagement.Application.Utility;

namespace ProjectManagement.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register your use case interfaces and implementations here

            //------------------- User Service ----------------------------------
            //services.AddScoped<IUserService, UserService>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();


            //------------------- Authentication ----------------------------------
            //services.AddScoped<ILoginUseCase, LoginUseCase>();


            //------------------- MediatR ----------------------------------
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetUserByIdQuery).Assembly));

            //services.AddMediatR(Assembly.GetExecutingAssembly());


            //------------------- FluentValidation ----------------------------------
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Register ValidationBehavior for MediatR pipeline
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            //------------------- Auto Mapper ----------------------------------
            services.AddAutoMapper(typeof(UserMappingProfile));



            //------------------- Memory Cache Registration ----------------------------------
            //services.AddMemoryCache();

            // Repeat for other entities as needed

            return services;
        }
    }
}
