using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.UserDetails.Query
{
    public class GetUserByEmailQuery : IRequest<ResponseDto<UserDto>>
    {
        public string Email { get; set; }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
