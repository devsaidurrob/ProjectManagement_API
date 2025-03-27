using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.UserDetails.Query
{
    public class GetUserByUserNameQuery : IRequest<ResponseDto<UserDto>>
    {
        public string UserName { get; set; }

        public GetUserByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
