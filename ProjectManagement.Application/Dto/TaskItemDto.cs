namespace ProjectManagement.Application.Dto
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int StoryId { get; set; }
        public string Status { get; set; } = string.Empty;
        //public StoryDto Story { get; set; } = new StoryDto();
    }
}
