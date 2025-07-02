using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.Utility;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.Auth.Command;

namespace ProjectManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtService _jwtService;
        public AuthController(IMediator mediator, JwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }

        [HttpPatch]
        public async Task<ResponseDto<AuthResultDto>> Login([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                result.Data.Token = _jwtService.GenerateToken(result.Data);
                return result;
            }
            return result;
        }
    }
}
