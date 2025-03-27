using MediatR;
using ProjectManagement.Application.Dto;
using System.Collections.Generic;

namespace ProjectManagement.Application.UseCases.SprintDetails.Query
{
    public class GetSprintsByProjectIdQuery : IRequest<ResponseDto<IEnumerable<SprintDto>>>
    {
        public int ProjectId { get; set; }

        public GetSprintsByProjectIdQuery(int projectId)
        {
            ProjectId = projectId;
        }
    }
}

