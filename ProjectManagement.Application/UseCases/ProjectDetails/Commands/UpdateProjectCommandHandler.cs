using System.Threading;
using System.Threading.Tasks;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Interfaces;

namespace ProjectManagement.Application.UseCases.ProjectDetails.Commands
{
    public class UpdateProjectCommandHandler
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Project?> Handle(UpdateProjectCommand command, CancellationToken cancellationToken)
        {
            var existingProject = await _projectRepository.GetProjectByIdAsync(command.Id);
            if (existingProject == null)
            {
                return null;
            }

            existingProject.Name = command.Name;
            existingProject.Description = command.Description;
            existingProject.StartDate = command.StartDate;
            existingProject.EndDate = command.EndDate;
            existingProject.OwnerId = command.OwnerId;

            var updatedProject = await _projectRepository.UpdateProjectAsync(existingProject);
            await _unitOfWork.SaveChangesAsync();
            return updatedProject;
        }
    }
}
