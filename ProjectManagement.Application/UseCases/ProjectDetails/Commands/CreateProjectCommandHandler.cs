using System.Threading;
using System.Threading.Tasks;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Interfaces;

namespace ProjectManagement.Application.UseCases.ProjectDetails.Commands
{
    public class CreateProjectCommandHandler
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Project> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Name = command.Name,
                Description = command.Description,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                OwnerId = command.OwnerId
            };

            await _projectRepository.AddProjectAsync(project);
            await _unitOfWork.SaveChangesAsync();
            return project;
        }
    }
}
