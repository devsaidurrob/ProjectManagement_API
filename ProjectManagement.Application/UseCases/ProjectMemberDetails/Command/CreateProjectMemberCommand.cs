using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.ProjectMemberDetails.Command
{
    public class CreateProjectMemberCommand : IRequest<ResponseDto<bool>>
    {
        public int ProjectId { get; set; }
        public List<ProjectMemberDetails> ProjectMembers { get; set; }
    }
    public class ProjectMemberDetails {
        public int UserId { get; set; }
        public string Role { get; set; }
    }
}
