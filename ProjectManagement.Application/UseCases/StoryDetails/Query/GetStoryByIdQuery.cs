using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.StoryDetails.Query
{
    public class GetStoryByIdQuery : IRequest<ResponseDto<StoryDto>>
    {
        public int Id { get; set; }

        public GetStoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
