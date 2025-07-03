using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.TaskDetails.Query
{
    public class GetTaskByProjectIdQuery : IRequest<ResponseDto<IEnumerable<TaskItemDto>>>
    {
        public int projectId { get; set; }
        public GetTaskByProjectIdQuery(int ProjectId)
        {
            projectId = ProjectId;
        }
    }
}
