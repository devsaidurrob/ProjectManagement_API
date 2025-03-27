using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core;

namespace ProjectManagement.Application.UseCases.UserDetails.Query
{
    public class GetUserByIdQuery : IRequest<ResponseDto<UserDto>>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
