using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.EpicDetails.Command;
using ProjectManagement.Core.Entities;

namespace ProjectManagement.Application.Mapper
{
    public class EpicMappingProfile : Profile
    {
        public EpicMappingProfile()
        {
            CreateMap<Epic, EpicDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<CreateEpicCommand, Epic>();
            CreateMap<UpdateEpicCommand, Epic>();
        }
    }
}
