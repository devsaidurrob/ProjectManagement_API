using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Infrastructure.Interfaces;

namespace ProjectManagement.Application.UseCases.ProjectDetails.Commands
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, ResponseDto<bool>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProjectCommandHandler(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<bool>> Handle(DeleteProjectCommand command, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectByIdAsync(command.Id);
            if (project == null)
            {
                return ResponseDto<bool>.ErrorResponse();
            }

            await _projectRepository.DeleteProjectAsync(command.Id);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDto<bool>.SuccessResponse(true);
        }
    }
}
