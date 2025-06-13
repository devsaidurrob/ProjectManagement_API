using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Entities;
using System.Collections.Generic;

namespace ProjectManagement.Application.UseCases.ProjectDetails.Query
{
    public class GetAllProjectsQuery : IRequest<ResponseDto<IEnumerable<ProjectDto>>>
    {
    }
}
