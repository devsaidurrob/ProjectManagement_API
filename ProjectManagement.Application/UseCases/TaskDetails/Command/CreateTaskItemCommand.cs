using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.TaskItemDetails.Command
{
    public class CreateTaskItemCommand : IRequest<ResponseDto<TaskItemDto>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StoryId { get; set; }
        public bool IsCompleted { get; set; }
        public int AssignedUserId { get; set; }

        public CreateTaskItemCommand(string title, string description, int storyId, bool isCompleted, int assignedUserId)
        {
            Title = title;
            Description = description;
            StoryId = storyId;
            IsCompleted = isCompleted;
            AssignedUserId = assignedUserId;
        }
    }
}

