using AutoMapper;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.Auth.Command;
using ProjectManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Mapper
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            CreateMap<RegisterCommand, AppUser>();
            CreateMap<LoginCommand, AppUser>();
            CreateMap<AppUser,AuthResultDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
