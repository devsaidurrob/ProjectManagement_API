using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.Events;
using ProjectManagement.Infrastructure.Interfaces;

namespace ProjectManagement.Application.UseCases.TaskDetails.Command
{
    internal class ChangeTaskStatusCommandHandler : IRequestHandler<ChangeTaskStatusCommand, ResponseDto<TaskItemDto>>
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ChangeTaskStatusCommandHandler(ITaskItemRepository taskItemRepository, IUnitOfWork unitOfWork, IMediator mediator, IMapper mapper)
        {
            _taskItemRepository = taskItemRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<ResponseDto<TaskItemDto>> Handle(ChangeTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskItemRepository.GetTaskByIdAsync(request.TaskId);
            if (task == null) throw new Exception("Task not found");

            task.Status = request.NewStatus;
            await _taskItemRepository.UpdateTaskAsync(task);
            await _unitOfWork.SaveChangesAsync();

            // Publishes a domain event: task status changed.
            await _mediator.Publish(new TaskStatusChangedEvent(task.Id, task.StoryId, request.NewStatus));

            var taskDto = _mapper.Map<TaskItemDto>(task);
            return ResponseDto<TaskItemDto>.SuccessResponse(taskDto);
        }
    }
}
