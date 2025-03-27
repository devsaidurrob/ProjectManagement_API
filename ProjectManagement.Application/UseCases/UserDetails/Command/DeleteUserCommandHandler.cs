using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.UserDetails.Command
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResponseDto<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<UserDto>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);
            if (user == null)
            {
                return ResponseDto<UserDto>.ErrorResponse("User not found", 404);
            }

            var data = await _userRepository.DeleteUserAsync(user);
            if(data == 0)
            {
                return ResponseDto<UserDto>.ErrorResponse("An Error Occured", 404);
            }
            return ResponseDto<UserDto>.SuccessResponse(_mapper.Map<UserDto>(user),200, "Deleted successfully");
        }
    }
}

