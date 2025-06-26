using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.ProjectMemberDetails.Command
{
    public class CreateProjectMemberCommandHandler : IRequestHandler<CreateProjectMemberCommand, ResponseDto<bool>>
    {
        private readonly IProjectMemberRepository _projectMemberRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProjectMemberCommandHandler(IProjectMemberRepository projectMemberRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _projectMemberRepository = projectMemberRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<bool>> Handle(CreateProjectMemberCommand request, CancellationToken cancellationToken)
        {
            var projectMembers = request.ProjectMembers.Select(x => new ProjectMember()
            {
                UserId = x.UserId,
                Role = x.Role,
                ProjectId = request.ProjectId
            }).ToList();

            var existingProjectMemebers = await _projectMemberRepository.GetProjectMembersByProjectIdAsync(request.ProjectId);

            _projectMemberRepository.RemoveProjectMembers(existingProjectMemebers);
            await _unitOfWork.SaveChangesAsync();

            var addedProjectMember = await _projectMemberRepository.AddProjectMembersAsync(projectMembers);
            await _unitOfWork.SaveChangesAsync();
            var projectMemberDto = _mapper.Map<IEnumerable<ProjectMemberDto>>(addedProjectMember);
            return ResponseDto<bool>.SuccessResponse(true);
        }
    }
}
