using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.Dto
{
    public class ProjectMemberDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        //public ProjectDto Project { get; set; } = new ProjectDto();
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public UserDto User { get; set; } = new UserDto();
        public string Role { get; set; } = string.Empty;

    }
}
