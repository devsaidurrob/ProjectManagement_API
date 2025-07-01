using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.TaskDetails.Command;
using ProjectManagement.Application.UseCases.TaskDetails.Query;
using ProjectManagement.Application.UseCases.TaskItemDetails.Command;
using ProjectManagement.Application.UseCases.TaskItemDetails.Query;

namespace ProjectManagement.API.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskItemController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ResponseDto<IEnumerable<TaskItemDto>>> GetAllTask()
        {
            var result = await _mediator.Send(new GetAllTaskItemsQuery());
            return result;
        }
        [HttpGet("by-project/{projectId}")]
        public async Task<ResponseDto<IEnumerable<TaskItemDto>>> GetTaskByProject(int projectId)
        {
            var result = await _mediator.Send(new GetTaskByProjectIdQuery(projectId));
            return result;
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<TaskItemDto>> GetTaskById(int id)
        {
            var result = await _mediator.Send(new GetTaskItemByIdQuery(id));
            return result;
        }
        [HttpPut("{id}/status")]
        public async Task<ResponseDto<TaskItemDto>> ChangeStatus(int id, [FromBody] ChangeTaskStatusCommand command)
        {
            var result = await _mediator.Send(new ChangeTaskStatusCommand(id, command.NewStatus));
            return result;
        }
        [HttpPost]
        public async Task<ResponseDto<TaskItemDto>> CreateTask([FromBody] CreateTaskItemCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpDelete("{id}")]
        public async Task<ResponseDto<bool>> DeleteTask(int id)
        {
            var result = await _mediator.Send(new DeleteTaskItemCommand(id));
            return result;
        }


        [HttpGet("comments/{taskId}")]
        public async Task<ResponseDto<IEnumerable<CommentDto>>> GetTaskComments(int taskId)
        {
            var result = await _mediator.Send(new GetTaskCommentsQuery(taskId));
            return result;
        }
    }
}
