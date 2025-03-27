using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.UserDetails.Command
{
    public class CreateUserCommand : IRequest<ResponseDto<UserDto>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        internal string PasswordHash { get; set; }

        public CreateUserCommand(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
