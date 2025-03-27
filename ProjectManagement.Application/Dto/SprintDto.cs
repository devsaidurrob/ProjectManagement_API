using System;
using System.Collections.Generic;

namespace ProjectManagement.Application.Dto
{
    public class SprintDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectId { get; set; }
        public ProjectDto Project { get; set; } = new ProjectDto();
        //public ICollection<SprintTas> SprintTasks { get; set; } = new List<SprintTaskDto>();
    }
}
