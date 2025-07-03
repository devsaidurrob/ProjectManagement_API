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
using ProjectManagement.Infrastructure.Interfaces;

namespace ProjectManagement.Application.UseCases.Auth.Command
{
    internal class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseDto<AuthResultDto>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public LoginCommandHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _repository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
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
                return ResponseDto<AuthResultDto>.SuccessResponse(_mapper.Map<AuthResultDto>(user));
            }
            else
            {
                return ResponseDto<AuthResultDto>.ErrorResponse("Invalid Password", 401);
            }
        }
    }
}
