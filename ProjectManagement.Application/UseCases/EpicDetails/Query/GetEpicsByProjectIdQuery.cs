using MediatR;
using ProjectManagement.Application.Dto;
using System.Collections.Generic;

namespace ProjectManagement.Application.UseCases.EpicDetails.Query
{
    public class GetEpicsByProjectIdQuery : IRequest<ResponseDto<IEnumerable<EpicDto>>>
    {
        public int ProjectId { get; set; }

        public GetEpicsByProjectIdQuery(int projectId)
        {
            ProjectId = projectId;
        }
    }
}
