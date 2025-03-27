using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.ProjectMemberDetails.Query
{
    public class GetProjectMemberByIdQuery : IRequest<ResponseDto<ProjectMemberDto>>
    {
        public int Id { get; set; }

        public GetProjectMemberByIdQuery(int id)
        {
            Id = id;
        }
    }
}
