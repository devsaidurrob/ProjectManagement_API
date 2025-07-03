using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.TaskItemDetails.Query;
using ProjectManagement.Application.Interfaces;

namespace ProjectManagement.Application.UseCases.TaskDetails.Query
{
    public class GetTaskByProjectIdQueryHandler : IRequestHandler<GetTaskByProjectIdQuery, ResponseDto<IEnumerable<TaskItemDto>>>
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMapper _mapper;

        public GetTaskByProjectIdQueryHandler(ITaskItemRepository taskItemRepository, IMapper mapper)
        {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<IEnumerable<TaskItemDto>>> Handle(GetTaskByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var taskItems = await _taskItemRepository.GetTasksByProjectAsync(request.projectId);
            var taskItemDtos = _mapper.Map<IEnumerable<TaskItemDto>>(taskItems);
            return ResponseDto<IEnumerable<TaskItemDto>>.SuccessResponse(taskItemDtos);
        }
    }
}
