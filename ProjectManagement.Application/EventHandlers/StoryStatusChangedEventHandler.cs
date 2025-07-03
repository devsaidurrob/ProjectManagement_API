using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProjectManagement.Application.Events;
using ProjectManagement.Application.Interfaces;

namespace ProjectManagement.Application.EventHandlers
{
    internal class StoryStatusChangedEventHandler : INotificationHandler<StoryStatusChangedEvent>
    {
        private readonly IStoryRepository _storyRepo;
        private readonly IEpicRepository _epicRepo;
        private readonly IUnitOfWork _unitOfWork;

        public StoryStatusChangedEventHandler(IStoryRepository storyRepo, IEpicRepository epicRepo, IUnitOfWork unitOfWork)
        {
            _storyRepo = storyRepo;
            _epicRepo = epicRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(StoryStatusChangedEvent notification, CancellationToken cancellationToken)
        {
            var stories = await _storyRepo.GetStoriesByEpicIdAsync(notification.EpicId);
            var epic = await _epicRepo.GetEpicByIdAsync(notification.EpicId);

            if (stories.All(s => s.Status == Core.Enums.TaskStatus.Done))
                epic.Status = Core.Enums.TaskStatus.Done;
            else if (stories.Any(s => s.Status == Core.Enums.TaskStatus.InProgress))
                epic.Status = Core.Enums.TaskStatus.InProgress;
            else
                epic.Status = Core.Enums.TaskStatus.ToDo;

            await _epicRepo.UpdateEpicAsync(epic);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
