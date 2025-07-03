using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.TaskDetails.Query
{
    public class GetTaskCommentsQuery : IRequest<ResponseDto<IEnumerable<CommentDto>>>
    {
        public int taskId { get; set; }
        public GetTaskCommentsQuery(int TaskId)
        {
            taskId = TaskId;
        }
    }
}
