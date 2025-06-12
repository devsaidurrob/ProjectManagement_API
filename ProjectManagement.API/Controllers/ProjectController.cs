using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.ProjectDetails.Query;
using ProjectManagement.Application.UseCases.ProjectDetails.Commands;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProjectManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ResponseDto<ProjectDto>> GetProjectById(int id)
        {
            var query = new GetProjectByIdQuery(id);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet]
        public async Task<ResponseDto<IEnumerable<ProjectDto>>> GetAllProjects()
        {
            var query = new GetAllProjectsQuery();
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<ResponseDto<ProjectDto>> CreateProject([FromBody] CreateProjectCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ResponseDto<ProjectDto>> UpdateProject(int id, [FromBody] UpdateProjectCommand command)
        {
            if (id != command.Id)
            {
                return ResponseDto<ProjectDto>.ErrorResponse("Project ID mismatch", 400);
            }

            var result = await _mediator.Send(command);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ResponseDto<ProjectDto>> DeleteProject(int id)
        {
            var command = new DeleteProjectCommand(id);
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
