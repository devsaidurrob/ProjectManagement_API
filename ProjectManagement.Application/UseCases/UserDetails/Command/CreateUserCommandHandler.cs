using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.Interfaces;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.UserDetails.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseDto<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<ResponseDto<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.PasswordHash = _passwordHasher.HashPassword(request.Password);
            var user = _mapper.Map<User>(request);

            var addedUser = await _userRepository.AddUserAsync(user);
            var userDto = _mapper.Map<UserDto>(addedUser);
            return ResponseDto<UserDto>.SuccessResponse(userDto);
        }
    }
}
