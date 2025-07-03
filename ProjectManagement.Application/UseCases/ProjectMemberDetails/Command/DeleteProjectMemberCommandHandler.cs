using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.ProjectMemberDetails.Command
{
    public class DeleteProjectMemberCommandHandler : IRequestHandler<DeleteProjectMemberCommand, ResponseDto<ProjectMemberDto>>
    {
        private readonly IProjectMemberRepository _projectMemberRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProjectMemberCommandHandler(IProjectMemberRepository projectMemberRepository, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _projectMemberRepository = projectMemberRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProjectMemberDto>> Handle(DeleteProjectMemberCommand request, CancellationToken cancellationToken)
        {
            var existingProjectMember = await _projectMemberRepository.GetProjectMemberByIdAsync(request.Id);
            if (existingProjectMember == null)
            {
                return ResponseDto<ProjectMemberDto>.ErrorResponse("Project member not found", 404);
            }

            var deletedProjectMember = await _projectMemberRepository.DeleteProjectMemberAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();
            var deletedProjectMemberDto = _mapper.Map<ProjectMemberDto>(deletedProjectMember);
            return ResponseDto<ProjectMemberDto>.SuccessResponse(deletedProjectMemberDto);
        }
    }
}
