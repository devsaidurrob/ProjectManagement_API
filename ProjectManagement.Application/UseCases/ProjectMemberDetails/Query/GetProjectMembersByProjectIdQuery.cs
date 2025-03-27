using MediatR;
using ProjectManagement.Application.Dto;
using System.Collections.Generic;

namespace ProjectManagement.Application.UseCases.ProjectMemberDetails.Query
{
    public class GetProjectMembersByProjectIdQuery : IRequest<ResponseDto<IEnumerable<ProjectMemberDto>>>
    {
        public int ProjectId { get; set; }

        public GetProjectMembersByProjectIdQuery(int projectId)
        {
            ProjectId = projectId;
        }
    }
}
