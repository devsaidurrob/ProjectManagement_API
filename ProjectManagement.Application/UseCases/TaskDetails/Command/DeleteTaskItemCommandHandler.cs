using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.TaskItemDetails.Command
{
    public class DeleteTaskItemCommandHandler : IRequestHandler<DeleteTaskItemCommand, ResponseDto<bool>>
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaskItemCommandHandler(ITaskItemRepository taskItemRepository, IUnitOfWork unitOfWork)
        {
            _taskItemRepository = taskItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<bool>> Handle(DeleteTaskItemCommand request, CancellationToken cancellationToken)
        {
            var existingTaskItem = await _taskItemRepository.GetTaskByIdAsync(request.Id);
            if (existingTaskItem == null)
            {
                return ResponseDto<bool>.ErrorResponse("Task item not found", 404);
            }

            await _taskItemRepository.DeleteTaskAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();

            return ResponseDto<bool>.SuccessResponse(true);
        }
    }
}

