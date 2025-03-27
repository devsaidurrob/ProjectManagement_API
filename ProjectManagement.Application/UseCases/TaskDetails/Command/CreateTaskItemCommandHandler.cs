using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Interfaces;
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
            await _unitOfWork.SaveChangesAsync();
            var taskItemDto = _mapper.Map<TaskItemDto>(addedTaskItem);
            return ResponseDto<TaskItemDto>.SuccessResponse(taskItemDto);
        }
    }
}

