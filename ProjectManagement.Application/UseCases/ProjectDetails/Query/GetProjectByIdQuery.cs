using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Entities;

namespace ProjectManagement.Application.UseCases.ProjectDetails.Query
{
    public class GetProjectByIdQuery : IRequest<ResponseDto<ProjectDto>>
    {
        public int Id { get; set; }

        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }
    }
}
