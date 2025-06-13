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
    public class SprintMappingProfile : Profile
    {
        public SprintMappingProfile()
        {
            CreateMap<Sprint, SprintDto>();
        }
    }
}
