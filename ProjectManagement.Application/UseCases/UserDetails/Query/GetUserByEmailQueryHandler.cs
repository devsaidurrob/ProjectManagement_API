using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.UserDetails.Query
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, ResponseDto<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByEmailQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<UserDto>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                return ResponseDto<UserDto>.ErrorResponse("User not found", 404);
            }
            var userDto = _mapper.Map<UserDto>(user);
            return ResponseDto<UserDto>.SuccessResponse(userDto);
        }
    }
}
