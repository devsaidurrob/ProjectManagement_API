using MediatR;
using ProjectManagement.Application.Dto;
using System.Collections.Generic;

namespace ProjectManagement.Application.UseCases.ProjectMemberDetails.Query
{
    public class GetAllProjectMembersQuery : IRequest<ResponseDto<IEnumerable<ProjectMemberDto>>>
    {
    }
}
