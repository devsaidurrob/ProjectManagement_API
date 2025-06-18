using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ProjectManagement.Application.Events
{
    internal class StoryStatusChangedEvent : INotification
    {
        public int StoryId { get; }
        public int EpicId { get; }
        public Core.Enums.TaskStatus NewStatus { get; }

        public StoryStatusChangedEvent(int storyId, int epicId, Core.Enums.TaskStatus newStatus)
        {
            StoryId = storyId;
            EpicId = epicId;
            NewStatus = newStatus;
        }
    }
}
