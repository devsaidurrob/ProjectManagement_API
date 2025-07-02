using AutoMapper;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.UserDetails.Command;
using ProjectManagement.Core.Entities;

namespace ProjectManagement.Application.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<AppUser, UserDto>();
            CreateMap<CreateUserCommand, AppUser>();
        }
    }
}
