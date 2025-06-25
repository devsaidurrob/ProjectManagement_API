using MediatR;
using ProjectManagement.Application.Dto;
using System.Collections.Generic;

namespace ProjectManagement.Application.UseCases.UserDetails.Query
{
    public class GetAllUsersQuery : IRequest<ResponseDto<IEnumerable<UserDto>>>
    {
    }
}
