using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProjectManagement.Application.Events;
using ProjectManagement.Infrastructure.Interfaces;

namespace ProjectManagement.Application.EventHandlers
{
    internal class TaskStatusChangedEventHandler : INotificationHandler<TaskStatusChangedEvent>
    {
        private readonly ITaskItemRepository _taskRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStoryRepository _storyRepo;
        private readonly IMediator _mediator;

        public TaskStatusChangedEventHandler(ITaskItemRepository taskRepo, IStoryRepository storyRepo,  IMediator mediator, IUnitOfWork unitOfWork)
        {
            _taskRepo = taskRepo;
            _storyRepo = storyRepo;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(TaskStatusChangedEvent notification, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepo.GetTasksByStoryIdAsync(notification.StoryId);
            var story = await _storyRepo.GetStoryByIdAsync(notification.StoryId);

            if (tasks.All(t => t.Status == Core.Enums.TaskStatus.Done))
                story.Status = Core.Enums.TaskStatus.Done;
            else if (tasks.Any(t => t.Status == Core.Enums.TaskStatus.InProgress))
                story.Status = Core.Enums.TaskStatus.InProgress;
            else
                story.Status = Core.Enums.TaskStatus.ToDo;

            await _storyRepo.UpdateStoryAsync(story);
            await _unitOfWork.SaveChangesAsync();
            // Raise new domain event to update Epic.
            await _mediator.Publish(new StoryStatusChangedEvent(story.Id, story.EpicId, story.Status));
        }
    }
}
