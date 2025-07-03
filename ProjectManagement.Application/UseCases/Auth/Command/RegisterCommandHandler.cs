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
using ProjectManagement.Infrastructure.Repositories;

namespace ProjectManagement.Application.UseCases.Auth.Command
{
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, ResponseDto<AuthResultDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }
        public async Task<ResponseDto<AuthResultDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            AppUser existingUser =null;
            existingUser = await _userRepository.GetUserByUserNameAsync(request.Username);
            if (existingUser != null)
                return ResponseDto<AuthResultDto>.ErrorResponse("User Name already Exists", 400);
            existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
            if (existingUser != null)
                return ResponseDto<AuthResultDto>.ErrorResponse("Email already Exists", 400);
            existingUser = await _userRepository.FindByIdentifier(request.MobileNumber);
            if (existingUser != null)
                return ResponseDto<AuthResultDto>.ErrorResponse("Mobile No. already Exists", 400);
            var user = _mapper.Map<AppUser>(request);
            user.PasswordHash = _passwordHasher.HashPassword(request.Password);
            var addedUser = await _userRepository.AddUserAsync(user);
            await _unitOfWork.SaveChangesAsync();
            var userDto = _mapper.Map<AuthResultDto>(addedUser);
            return ResponseDto<AuthResultDto>.SuccessResponse(userDto);
        }
    }
}
