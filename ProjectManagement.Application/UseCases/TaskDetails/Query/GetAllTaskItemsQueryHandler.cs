using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.TaskItemDetails.Query
{
    public class GetAllTaskItemsQueryHandler : IRequestHandler<GetAllTaskItemsQuery, ResponseDto<IEnumerable<TaskItemDto>>>
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMapper _mapper;

        public GetAllTaskItemsQueryHandler(ITaskItemRepository taskItemRepository, IMapper mapper)
        {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<IEnumerable<TaskItemDto>>> Handle(GetAllTaskItemsQuery request, CancellationToken cancellationToken)
        {
            var taskItems = await _taskItemRepository.GetAllTasksAsync();
            var taskItemDtos = _mapper.Map<IEnumerable<TaskItemDto>>(taskItems);
            return ResponseDto<IEnumerable<TaskItemDto>>.SuccessResponse(taskItemDtos);
        }
    }
}

