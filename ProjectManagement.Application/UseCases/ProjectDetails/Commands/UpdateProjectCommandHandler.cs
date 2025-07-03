using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.UserDetails.Command;
using ProjectManagement.Core.Entities;
using ProjectManagement.Application.Interfaces;

namespace ProjectManagement.Application.UseCases.ProjectDetails.Commands
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, ResponseDto<ProjectDto>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProjectDto>> Handle(UpdateProjectCommand command, CancellationToken cancellationToken)
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
            //existingProject.CompanyId = 1;

            var updatedProject = await _projectRepository.UpdateProjectAsync(existingProject);
            await _unitOfWork.SaveChangesAsync();
            var updatedProjectDto = _mapper.Map<ProjectDto>(updatedProject);
            return ResponseDto<ProjectDto>.SuccessResponse(updatedProjectDto);
        }
    }
}
