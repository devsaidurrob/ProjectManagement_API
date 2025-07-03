using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.Auth.Command;

namespace ProjectManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch]
        [AllowAnonymous]
        public async Task<ResponseDto<AuthResultDto>> Login([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ResponseDto<AuthResultDto>> Register([FromBody] RegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
