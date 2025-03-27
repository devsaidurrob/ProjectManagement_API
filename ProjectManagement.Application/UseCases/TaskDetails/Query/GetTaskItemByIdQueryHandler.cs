using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.TaskItemDetails.Query
{
    public class GetTaskItemByIdQueryHandler : IRequestHandler<GetTaskItemByIdQuery, ResponseDto<TaskItemDto>>
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMapper _mapper;

        public GetTaskItemByIdQueryHandler(ITaskItemRepository taskItemRepository, IMapper mapper)
        {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<TaskItemDto>> Handle(GetTaskItemByIdQuery request, CancellationToken cancellationToken)
        {
            var taskItem = await _taskItemRepository.GetTaskByIdAsync(request.Id);
            if (taskItem == null)
            {
                return ResponseDto<TaskItemDto>.ErrorResponse("Task item not found", 404);
            }
            var taskItemDto = _mapper.Map<TaskItemDto>(taskItem);
            return ResponseDto<TaskItemDto>.SuccessResponse(taskItemDto);
        }
    }
}

