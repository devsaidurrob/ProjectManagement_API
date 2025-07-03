using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Entities;
using ProjectManagement.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.UserDetails.Query
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ResponseDto<IEnumerable<UserDto>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<IEnumerable<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsersAsync();
            var userDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return ResponseDto<IEnumerable<UserDto>>.SuccessResponse(userDto);
        }
    }
}
