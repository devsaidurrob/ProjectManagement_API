using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.ProjectMemberDetails.Command;
using ProjectManagement.Application.UseCases.ProjectMemberDetails.Query;
using ProjectManagement.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectMemberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectMemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ProjectMember/project/5
        [HttpGet("project/{projectId}")]
        public async Task<ResponseDto<IEnumerable<ProjectMemberDto>>> GetByProject(int projectId)
        {
            var result = await _mediator.Send(new GetProjectMembersByProjectIdQuery(projectId));
            return result;
        }
        [HttpDelete("{id}")]
        public async Task<ResponseDto<ProjectMemberDto>> DeleteProjectMember(int id)
        {
            var result = await _mediator.Send(new DeleteProjectMemberCommand(id));
            return result;
        }

        // PUT: api/ProjectMember/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody] UpdateProjectMemberDto dto)
        //{
        //    if (id != dto.Id)
        //        return BadRequest("ID mismatch.");

        //    var command = new UpdateProjectMemberCommand(dto);
        //    var result = await _mediator.Send(command);

        //    if (!result.Success)
        //        return NotFound(result.Message);

        //    return NoContent();
        //}
    }
}
