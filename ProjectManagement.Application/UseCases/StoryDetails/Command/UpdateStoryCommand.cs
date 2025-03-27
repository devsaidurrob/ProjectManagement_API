using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.StoryDetails.Command
{
    public class UpdateStoryCommand : IRequest<ResponseDto<StoryDto>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EpicId { get; set; }

        public UpdateStoryCommand(int id, string title, string description, int epicId)
        {
            Id = id;
            Title = title;
            Description = description;
            EpicId = epicId;
        }
    }
}
