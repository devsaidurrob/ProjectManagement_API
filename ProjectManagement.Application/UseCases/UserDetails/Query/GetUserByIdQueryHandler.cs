using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.UserDetails.Query
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResponseDto<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);
            if (user == null)
            {
                return ResponseDto<UserDto>.ErrorResponse("User not found", 404);
            }
            var userDto = _mapper.Map<UserDto>(user);
            return ResponseDto<UserDto>.SuccessResponse(userDto);
        }
    }
}
