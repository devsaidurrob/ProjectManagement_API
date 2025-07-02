
using AutoMapper;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.UseCases.TaskItemDetails.Command;
using ProjectManagement.Core.Entities;

namespace ProjectManagement.Application.Mapper
{
    public class TaskItemMappingProfile : Profile
    {
        public TaskItemMappingProfile()
        {
            CreateMap<TaskItem, TaskItemDto>()
                .ForMember(dest => dest.AssignedUserFullName, opt => opt.MapFrom(src => src.AssignedUser.Username));

            CreateMap<TaskItemDto, TaskItem>();

            CreateMap<CreateTaskItemCommand, TaskItem>()
                .ForMember(dest => dest.Story, opt => opt.Ignore()) // Prevent EF Core from trying to insert new Story
                .ForMember(dest => dest.AssignedUser, opt => opt.Ignore())
                .ForMember(dest => dest.SprintTasks, opt => opt.Ignore())
                .ForMember(dest => dest.Comments, opt => opt.Ignore())
                .ForMember(dest => dest.Attachments, opt => opt.Ignore())
                .ForMember(dest => dest.ActivityLogs, opt => opt.Ignore());

            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.Username));
        }
    }
}
