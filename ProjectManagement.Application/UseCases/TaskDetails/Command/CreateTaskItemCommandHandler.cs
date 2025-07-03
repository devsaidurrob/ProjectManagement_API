using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Entities;
using ProjectManagement.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.TaskItemDetails.Command
{
    public class CreateTaskItemCommandHandler : IRequestHandler<CreateTaskItemCommand, ResponseDto<TaskItemDto>>
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTaskItemCommandHandler(ITaskItemRepository taskItemRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _taskItemRepository = taskItemRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<TaskItemDto>> Handle(CreateTaskItemCommand request, CancellationToken cancellationToken)
        {
            var taskItem = _mapper.Map<TaskItem>(request);
            var addedTaskItem = await _taskItemRepository.AddTaskAsync(taskItem);
            int retVal = await _unitOfWork.SaveChangesAsync();
            if(retVal > 0)
            {
                var createdTask = await _taskItemRepository.GetTaskByIdAsync(addedTaskItem.Id);
                var taskItemDto = _mapper.Map<TaskItemDto>(createdTask);
                return ResponseDto<TaskItemDto>.SuccessResponse(taskItemDto);
            }
            
            return ResponseDto<TaskItemDto>.ErrorResponse();
        }
    }
}

