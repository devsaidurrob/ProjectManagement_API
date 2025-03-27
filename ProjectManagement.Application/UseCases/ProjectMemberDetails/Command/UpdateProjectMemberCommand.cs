using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.ProjectMemberDetails.Command
{
    public class UpdateProjectMemberCommand : IRequest<ResponseDto<ProjectMemberDto>>
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }

        public UpdateProjectMemberCommand(int id, int projectId, int userId, string role)
        {
            Id = id;
            ProjectId = projectId;
            UserId = userId;
            Role = role;
        }
    }
}
