using System.Text.Json.Serialization;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Enums;

namespace ProjectManagement.Application.UseCases.TaskItemDetails.Command
{
    public class CreateTaskItemCommand : IRequest<ResponseDto<TaskItemDto>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        [JsonPropertyName("assignTo")]
        public int AssignedUserId { get; set; }
        [JsonPropertyName("project")]
        public int ProjectId { get; set; }
        [JsonPropertyName("epic")]
        public int EpicId { get; set; }
        [JsonPropertyName("story")]
        public int StoryId { get; set; }    
        public int Tag { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Estimate { get; set; }
        public string? EstimateUnit { get; set; }

        //public CreateTaskItemCommand(string title, string description, int storyId, bool isCompleted, int assignedUserId)
        //{
        //    Title = title;
        //    Description = description;
        //    StoryId = storyId;
        //    IsCompleted = isCompleted;
        //    AssignedUserId = assignedUserId;
        //}
    }
}

