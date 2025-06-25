using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.UserDetails.Command;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Interfaces;

namespace ProjectManagement.Application.UseCases.ProjectDetails.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ResponseDto<ProjectDto>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProjectDto>> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Name = command.Name,
                Description = command.Description,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                OwnerId = 1
            };

            var createdProject = await _projectRepository.AddProjectAsync(project);
            await _unitOfWork.SaveChangesAsync();
            var createdProjectDto = _mapper.Map<ProjectDto>(createdProject);
            return ResponseDto<ProjectDto>.SuccessResponse(createdProjectDto);
        }
    }
}
