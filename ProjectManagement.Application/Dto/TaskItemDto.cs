using ProjectManagement.Core.Entities;
using ProjectManagement.Core.Enums;

namespace ProjectManagement.Application.Dto
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int StoryId { get; set; }
        public string Status { get; set; } = string.Empty;
        
        public string Priority { get; set; } = string.Empty;
        public string AssignedUserId { get; set; } = string.Empty;
        public string AssignedUserName { get; set; } = string.Empty;
        public string AssignedUserFullName { get; set; } = string.Empty;
        public string AssignedUserAvatar { get; set; } = string.Empty;
        //public StoryDto Story { get; set; }
        public int ProjectId { get; set; }
        public int EpicId { get; set; }
        public TaskTag Tag { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Estimate { get; set; }
        public string? EstimateUnit { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<AttachmentDto> Attachments { get; set; }
        public List<ActivityLogDto> ActivityLogs { get; set; }
    }
}
