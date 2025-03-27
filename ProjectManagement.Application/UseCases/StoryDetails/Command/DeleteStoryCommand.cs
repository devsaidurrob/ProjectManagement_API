using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.StoryDetails.Command
{
    public class DeleteStoryCommand : IRequest<ResponseDto<bool>>
    {
        public int Id { get; set; }

        public DeleteStoryCommand(int id)
        {
            Id = id;
        }
    }
}
