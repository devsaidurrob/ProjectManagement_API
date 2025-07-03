using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.StoryDetails.Query;
using ProjectManagement.Application.UseCases.StoryDetails.Command;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Story
        [HttpGet]
        public async Task<ResponseDto<IEnumerable<StoryDto>>> GetAll()
        {
            return await _mediator.Send(new GetAllStoriesQuery());
        }

        // GET: api/Story/epic/5
        [HttpGet("by-epic/{epicId}")]
        public async Task<ResponseDto<IEnumerable<StoryDto>>> GetByEpicId(int epicId)
        {
            return await _mediator.Send(new GetStoriesByEpicIdQuery(epicId));
        }

        // GET: api/Story/5
        [HttpGet("{id}")]
        public async Task<ResponseDto<StoryDto>> GetById(int id)
        {
            return await _mediator.Send(new GetStoryByIdQuery(id));
        }

        // POST: api/Story
        [HttpPost]
        public async Task<ResponseDto<StoryDto>> Create([FromBody] CreateStoryCommand command)
        {
            return await _mediator.Send(command);
        }

        // PUT: api/Story/5
        [HttpPut("{id}")]
        public async Task<ResponseDto<StoryDto>> Update(int id, [FromBody] UpdateStoryCommand command)
        {
            if (id != command.Id)
                return ResponseDto<StoryDto>.ErrorResponse("ID mismatch", 400);

            return await _mediator.Send(command);
        }

        // DELETE: api/Story/5
        [HttpDelete("{id}")]
        public async Task<ResponseDto<bool>> Delete(int id)
        {
            return await _mediator.Send(new DeleteStoryCommand(id));
        }
    }
}
