using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.ProjectMemberDetails.Command
{
    public class DeleteProjectMemberCommandHandler : IRequestHandler<DeleteProjectMemberCommand, ResponseDto<bool>>
    {
        private readonly IProjectMemberRepository _projectMemberRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProjectMemberCommandHandler(IProjectMemberRepository projectMemberRepository, IUnitOfWork unitOfWork)
        {
            _projectMemberRepository = projectMemberRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<bool>> Handle(DeleteProjectMemberCommand request, CancellationToken cancellationToken)
        {
            var existingProjectMember = await _projectMemberRepository.GetProjectMemberByIdAsync(request.Id);
            if (existingProjectMember == null)
            {
                return ResponseDto<bool>.ErrorResponse("Project member not found", 404);
            }

            await _projectMemberRepository.DeleteProjectMemberAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();

            return ResponseDto<bool>.SuccessResponse(true);
        }
    }
}
