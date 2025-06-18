using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.TaskDetails.Command;

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

        [HttpPut("{id}/status")]
        public async Task<ResponseDto<TaskItemDto>> ChangeStatus(int id, [FromBody] ChangeTaskStatusCommand command)
        {
            var result = await _mediator.Send(new ChangeTaskStatusCommand(id, command.NewStatus));
            return result;
        }
    }
}
