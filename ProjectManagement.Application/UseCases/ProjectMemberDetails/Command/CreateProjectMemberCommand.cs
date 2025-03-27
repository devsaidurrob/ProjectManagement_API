using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.ProjectMemberDetails.Command
{
    public class CreateProjectMemberCommand : IRequest<ResponseDto<ProjectMemberDto>>
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }

        public CreateProjectMemberCommand(int projectId, int userId, string role)
        {
            ProjectId = projectId;
            UserId = userId;
            Role = role;
        }
    }
}
