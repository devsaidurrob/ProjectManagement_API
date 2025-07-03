using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Application.Interfaces;
using ProjectManagement.Infrastructure.Repositories;
using ProjectManagement.Infrastructure.Services;

namespace ProjectManagement.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //------------------- User Service ----------------------------------
            //services.AddScoped<IUserService, UserService>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IJwtService, JwtService>();


            // Register your generic repository
            //services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register specific repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskItemRepository, TaskItemRepository>();
            services.AddScoped<IEpicRepository, EpicRepository>();
            services.AddScoped<ISprintRepository, SprintRepository>();
            services.AddScoped<IStoryRepository, StoryRepository>();
            services.AddScoped<IProjectMemberRepository, ProjectMemberRepository>();
            services.AddScoped<IAcceptanceCriteriaRepository, AcceptanceCriteriaRepository>();
            services.AddScoped<IActivityLogRepository, ActivityLogRepository>();
            services.AddScoped<IAttachmentRepository, AttachmentRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            return services;
        }
    }
}
