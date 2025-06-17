using System;
using System.Collections.Generic;

namespace ProjectManagement.Application.Dto
{
    public class EpicDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ProjectId { get; set; }
        //public ProjectDto Project { get; set; } = new ProjectDto();
        public ICollection<StoryDto> Stories { get; set; } = new List<StoryDto>();
    }
}
