using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.TaskItemDetails.Query
{
    public class GetTaskItemsByStoryIdQueryHandler : IRequestHandler<GetTaskItemsByStoryIdQuery, ResponseDto<IEnumerable<TaskItemDto>>>
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMapper _mapper;

        public GetTaskItemsByStoryIdQueryHandler(ITaskItemRepository taskItemRepository, IMapper mapper)
        {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<IEnumerable<TaskItemDto>>> Handle(GetTaskItemsByStoryIdQuery request, CancellationToken cancellationToken)
        {
            var taskItems = await _taskItemRepository.GetTasksByStoryIdAsync(request.StoryId);
            var taskItemDtos = _mapper.Map<IEnumerable<TaskItemDto>>(taskItems);
            return ResponseDto<IEnumerable<TaskItemDto>>.SuccessResponse(taskItemDtos);
        }
    }
}

