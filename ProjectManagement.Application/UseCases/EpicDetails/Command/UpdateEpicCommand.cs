using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.EpicDetails.Command
{
    public class UpdateEpicCommand : IRequest<ResponseDto<EpicDto>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }

        public UpdateEpicCommand(int id, string title, string description, int projectId)
        {
            Id = id;
            Title = title;
            Description = description;
            ProjectId = projectId;
        }
    }
}
