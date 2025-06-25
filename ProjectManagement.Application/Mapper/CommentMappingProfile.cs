using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Entities;

namespace ProjectManagement.Application.Mapper
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.Name));
        }
    }
}
