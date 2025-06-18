using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.TaskDetails.Command
{
    public class ChangeTaskStatusCommand : IRequest<ResponseDto<TaskItemDto>>
    {
        public int TaskId { get; set; }
        public Core.Enums.TaskStatus NewStatus { get; set; } // Assuming Status is an integer representing the TaskStatus enum
        public ChangeTaskStatusCommand(int taskId, Core.Enums.TaskStatus newStatus)
        {
            TaskId = taskId;
            NewStatus = newStatus;
        }
    }
}
