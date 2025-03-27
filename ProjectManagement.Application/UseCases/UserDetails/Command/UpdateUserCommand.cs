using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.UserDetails.Command
{
    public class UpdateUserCommand : IRequest<ResponseDto<UserDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public UpdateUserCommand(int id, string name, string email, string passwordHash)
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}

