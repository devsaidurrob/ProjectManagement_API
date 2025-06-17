using System.Collections.Generic;

namespace ProjectManagement.Application.Dto
{
    public class StoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int EpicId { get; set; }
        //public EpicDto Epic { get; set; } = new EpicDto();
        public ICollection<TaskItemDto> Tasks { get; set; } = new List<TaskItemDto>();
    }
}
