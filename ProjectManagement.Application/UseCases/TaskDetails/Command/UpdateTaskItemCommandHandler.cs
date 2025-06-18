using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.TaskItemDetails.Command
{
    public class UpdateTaskItemCommandHandler : IRequestHandler<UpdateTaskItemCommand, ResponseDto<TaskItemDto>>
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTaskItemCommandHandler(ITaskItemRepository taskItemRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _taskItemRepository = taskItemRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<TaskItemDto>> Handle(UpdateTaskItemCommand request, CancellationToken cancellationToken)
        {
            var existingTaskItem = await _taskItemRepository.GetTaskByIdAsync(request.Id);
            if (existingTaskItem == null)
            {
                return ResponseDto<TaskItemDto>.ErrorResponse("Task item not found", 404);
            }

            existingTaskItem.Title = request.Title;
            existingTaskItem.Description = request.Description;
            existingTaskItem.StoryId = request.StoryId;
            existingTaskItem.AssignedUserId = request.AssignedUserId;

            var updatedTaskItem = await _taskItemRepository.UpdateTaskAsync(existingTaskItem);
            await _unitOfWork.SaveChangesAsync();

            var taskItemDto = _mapper.Map<TaskItemDto>(updatedTaskItem);
            return ResponseDto<TaskItemDto>.SuccessResponse(taskItemDto);
        }
    }
}

