using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Infrastructure.Interfaces;

namespace ProjectManagement.Application.UseCases.TaskDetails.Query
{
    public class GetTaskCommentQueryHandler : IRequestHandler<GetTaskCommentsQuery, ResponseDto<IEnumerable<CommentDto>>>
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMapper _mapper;

        public GetTaskCommentQueryHandler(ITaskItemRepository taskItemRepository, IMapper mapper)
        {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<IEnumerable<CommentDto>>> Handle(GetTaskCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _taskItemRepository.GetTaskComments(request.taskId);
            var commentsDtos = _mapper.Map<IEnumerable<CommentDto>>(comments);
            return ResponseDto<IEnumerable<CommentDto>>.SuccessResponse(commentsDtos);
        }
    }
}
