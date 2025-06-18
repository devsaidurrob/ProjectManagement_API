using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ProjectManagement.Application.Events
{
    internal class TaskStatusChangedEvent : INotification
    {
        public int TaskId { get; }
        public int StoryId { get; }
        public Core.Enums.TaskStatus NewStatus { get; }

        public TaskStatusChangedEvent(int taskId, int storyId, Core.Enums.TaskStatus newStatus)
        {
            TaskId = taskId;
            StoryId = storyId;
            NewStatus = newStatus;
        }
    }
}
