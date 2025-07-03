using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.Interfaces;
using ProjectManagement.Core.Entities;

namespace ProjectManagement.Application.UseCases.Auth.Command
{
    internal class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseDto<AuthResultDto>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;
        public LoginCommandHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher, IJwtService jwtService)
        {
            _repository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<ResponseDto<AuthResultDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser();
            user = await _repository.FindByIdentifier(request.UserName);
            if (user == null)
            if (user == null)
                return ResponseDto<AuthResultDto>.ErrorResponse("Invalid UserName or Email", 401);
            if (_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
            {
                var userDto = _mapper.Map<AuthResultDto>(user);
                // Generate JWT Token
                userDto.Token = _jwtService.GenerateToken(userDto);

                return ResponseDto<AuthResultDto>.SuccessResponse(userDto);
            }
            else
            {
                return ResponseDto<AuthResultDto>.ErrorResponse("Invalid Password", 401);
            }
        }
    }
}
