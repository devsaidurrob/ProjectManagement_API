using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.ProjectMemberDetails.Command
{
    public class DeleteProjectMemberCommand : IRequest<ResponseDto<ProjectMemberDto>>
    {
        public int Id { get; set; }

        public DeleteProjectMemberCommand(int id)
        {
            Id = id;
        }
    }
}
