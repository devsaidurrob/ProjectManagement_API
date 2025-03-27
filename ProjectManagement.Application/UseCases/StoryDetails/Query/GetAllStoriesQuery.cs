using MediatR;
using ProjectManagement.Application.Dto;
using System.Collections.Generic;

namespace ProjectManagement.Application.UseCases.StoryDetails.Query
{
    public class GetAllStoriesQuery : IRequest<ResponseDto<IEnumerable<StoryDto>>>
    {
    }
}
