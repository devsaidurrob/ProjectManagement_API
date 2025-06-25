using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.UserDetails.Query;
using ProjectManagement.Application.UseCases.UserDetails.Command;
using System.Threading.Tasks;

namespace ProjectManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ResponseDto<IEnumerable<UserDto>>> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);
            return result;
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<UserDto>> GetUserById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet("by-username/{username}")]
        public async Task<ResponseDto<UserDto>> GetUserByUserName(string username)
        {
            var query = new GetUserByUserNameQuery(username);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet("by-email/{email}")]
        public async Task<ResponseDto<UserDto>> GetUserByEmail(string email)
        {
            var query = new GetUserByEmailQuery(email);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<ResponseDto<UserDto>> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ResponseDto<UserDto>> UpdateUser(int id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return ResponseDto<UserDto>.ErrorResponse("User ID mismatch", 400);
            }

            var result = await _mediator.Send(command);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ResponseDto<UserDto>> DeleteUser(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
