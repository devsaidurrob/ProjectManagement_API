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
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ResponseDto<ProjectDto>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository; // Assuming you have a user repository
        private readonly IProjectMemberRepository _projectMemberRepository; // Assuming you have a project member repository
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IProjectRepository projectRepository, IUserRepository userRepository,
           IProjectMemberRepository projectMemberRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository; // Injecting user repository to validate user existence\
            _projectMemberRepository = projectMemberRepository; // Injecting project member repository if needed
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProjectDto>> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
        {
            // Validate user existence
            var existingUserIds = await _userRepository.GetUsersByIdsAsync(command.projectMembers);

            var missingUserIds = command.projectMembers.Except(existingUserIds.Select(x => x.Id)).ToList();

            if (missingUserIds.Any())
            {
                return ResponseDto<ProjectDto>.ErrorResponse(
                    $"User Not Exists");
            }

            var project = new Project
            {
                Name = command.Name,
                Description = command.Description,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                CompanyId = 1
            };

            // Step 2: Begin transaction
            await using var transaction = await _unitOfWork.BeginTransactionAsync();

            try
            {
                var createdProject = await _projectRepository.AddProjectAsync(project);
                await _unitOfWork.SaveChangesAsync(); // Project ID is generated

                // Step 4: Add project members
                var projectMembers = existingUserIds.Select(user => new ProjectMember
                {
                    ProjectId = createdProject.Id,
                    UserId = user.Id
                }).ToList();

                await _projectMemberRepository.AddProjectMembersAsync(projectMembers);
                await _unitOfWork.SaveChangesAsync(); // Save members

                // Step 5: Commit transaction
                await transaction.CommitAsync();

                var createdProjectDto = _mapper.Map<ProjectDto>(createdProject);
                return ResponseDto<ProjectDto>.SuccessResponse(createdProjectDto);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                // Log ex if needed
                return ResponseDto<ProjectDto>.ErrorResponse("An error occurred while creating the project.");
            }
        }
    }
}
