using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.TaskItemDetails.Command
{
    public class UpdateTaskItemCommand : IRequest<ResponseDto<TaskItemDto>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StoryId { get; set; }
        public bool IsCompleted { get; set; }
        public int AssignedUserId { get; set; }

        public UpdateTaskItemCommand(int id, string title, string description, int storyId, bool isCompleted, int assignedUserId)
        {
            Id = id;
            Title = title;
            Description = description;
            StoryId = storyId;
            IsCompleted = isCompleted;
            AssignedUserId = assignedUserId;
        }
    }
}

