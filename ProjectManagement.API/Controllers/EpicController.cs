using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.EpicDetails.Command;
using ProjectManagement.Application.UseCases.EpicDetails.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpicController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EpicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("by-project/{projectId}")]
        public async Task<ResponseDto<IEnumerable<EpicDto>>> GetEpicsByProjectId(int projectId)
        {
            var query = new GetEpicsByProjectIdQuery(projectId);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ResponseDto<EpicDto>> GetEpicById(int id)
        {
            var query = new GetEpicByIdQuery(id);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet]
        public async Task<ResponseDto<IEnumerable<EpicDto>>> GetAllEpics()
        {
            var query = new GetAllEpicsQuery();
            var result = await _mediator.Send(query);
            return result;
        }
        [HttpPost]
        public async Task<ResponseDto<EpicDto>> CreateEpic([FromBody] CreateEpicCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ResponseDto<EpicDto>> UpdateEpic(int id, [FromBody] UpdateEpicCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ResponseDto<bool>> DeleteEpic(int id)
        {
            var command = new DeleteEpicCommand(id);
            var result = await _mediator.Send(command);
            return result;
        }

        // Add POST, PUT, DELETE as needed for full CRUD
    }
}
