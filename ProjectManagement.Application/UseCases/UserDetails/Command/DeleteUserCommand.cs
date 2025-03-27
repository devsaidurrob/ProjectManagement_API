using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.UserDetails.Command
{
    public class DeleteUserCommand : IRequest<ResponseDto<UserDto>>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}

