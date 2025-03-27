using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.ProjectMemberDetails.Command
{
    public class UpdateProjectMemberCommandHandler : IRequestHandler<UpdateProjectMemberCommand, ResponseDto<ProjectMemberDto>>
    {
        private readonly IProjectMemberRepository _projectMemberRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProjectMemberCommandHandler(IProjectMemberRepository projectMemberRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _projectMemberRepository = projectMemberRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProjectMemberDto>> Handle(UpdateProjectMemberCommand request, CancellationToken cancellationToken)
        {
            var existingProjectMember = await _projectMemberRepository.GetProjectMemberByIdAsync(request.Id);
            if (existingProjectMember == null)
            {
                return ResponseDto<ProjectMemberDto>.ErrorResponse("Project member not found", 404);
            }

            existingProjectMember.ProjectId = request.ProjectId;
            existingProjectMember.UserId = request.UserId;
            existingProjectMember.Role = request.Role;

            var updatedProjectMember = await _projectMemberRepository.UpdateProjectMemberAsync(existingProjectMember);
            await _unitOfWork.SaveChangesAsync();

            var projectMemberDto = _mapper.Map<ProjectMemberDto>(updatedProjectMember);
            return ResponseDto<ProjectMemberDto>.SuccessResponse(projectMemberDto);
        }
    }
}
