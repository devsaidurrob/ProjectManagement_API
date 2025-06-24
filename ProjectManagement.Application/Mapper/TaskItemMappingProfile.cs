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
    public class TaskItemMappingProfile : Profile
    {
        public TaskItemMappingProfile()
        {
            CreateMap<TaskItem, TaskItemDto>()
                .ForMember(dest => dest.AssignedUserFullName, opt => opt.MapFrom(src => src.AssignedUser.Name));

            CreateMap<TaskItemDto, TaskItem>();
        }
    }
}
