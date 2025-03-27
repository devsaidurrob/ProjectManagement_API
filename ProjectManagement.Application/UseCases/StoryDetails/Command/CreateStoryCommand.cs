using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.StoryDetails.Command
{
    public class CreateStoryCommand : IRequest<ResponseDto<StoryDto>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int EpicId { get; set; }

        public CreateStoryCommand(string title, string description, int epicId)
        {
            Title = title;
            Description = description;
            EpicId = epicId;
        }
    }
}
