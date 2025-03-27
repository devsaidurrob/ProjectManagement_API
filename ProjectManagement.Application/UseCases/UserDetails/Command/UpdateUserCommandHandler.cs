using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.UserDetails.Command
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseDto<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);
            if (user == null)
            {
                return ResponseDto<UserDto>.ErrorResponse("User not found", 404);
            }

            user.Name = request.Name;
            user.Email = request.Email;
            user.PasswordHash = request.PasswordHash;

            var updatedUser = await _userRepository.UpdateUserAsync(user);
            var userDto = _mapper.Map<UserDto>(updatedUser);
            return ResponseDto<UserDto>.SuccessResponse(userDto);
        }
    }
}

