using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.SprintDetails.Command
{
    public class DeleteSprintCommandHandler : IRequestHandler<DeleteSprintCommand, ResponseDto<bool>>
    {
        private readonly ISprintRepository _sprintRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSprintCommandHandler(ISprintRepository sprintRepository, IUnitOfWork unitOfWork)
        {
            _sprintRepository = sprintRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<bool>> Handle(DeleteSprintCommand request, CancellationToken cancellationToken)
        {
            var existingSprint = await _sprintRepository.GetSprintByIdAsync(request.Id);
            if (existingSprint == null)
            {
                return ResponseDto<bool>.ErrorResponse("Sprint not found", 404);
            }

            await _sprintRepository.DeleteSprintAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();

            return ResponseDto<bool>.SuccessResponse(true);
        }
    }
}

