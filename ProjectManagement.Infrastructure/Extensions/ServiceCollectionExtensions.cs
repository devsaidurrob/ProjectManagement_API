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
