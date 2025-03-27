using System;
using System.Collections.Generic;

namespace ProjectManagement.Application.Dto
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OwnerId { get; set; }
        public ICollection<EpicDto> Epics { get; set; } = new List<EpicDto>();
        public ICollection<SprintDto> Sprints { get; set; } = new List<SprintDto>();
        public ICollection<ProjectMemberDto> ProjectMembers { get; set; } = new List<ProjectMemberDto>();
    }
}
