using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.ProjectDetails.Commands;
using ProjectManagement.Core.Entities;

namespace ProjectManagement.Application.Mapper
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            // Project Create Command
            CreateMap<CreateProjectCommand, Project>();

            // Project Update Command
            CreateMap<UpdateProjectCommand, Project>();

            // Project Delete Command
            CreateMap<DeleteProjectCommand, Project>();

            // Project Query to DTO
            CreateMap<Project, ProjectDto>()
                .ForMember(dest => dest.TotalMembers, opt => opt.MapFrom(src => (src.ProjectMembers == null)? 0 : src.ProjectMembers.Count()));

        }
    }
}
