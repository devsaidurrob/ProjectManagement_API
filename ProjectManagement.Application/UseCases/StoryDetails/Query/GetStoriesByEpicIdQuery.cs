using MediatR;
using ProjectManagement.Application.Dto;
using System.Collections.Generic;

namespace ProjectManagement.Application.UseCases.StoryDetails.Query
{
    public class GetStoriesByEpicIdQuery : IRequest<ResponseDto<IEnumerable<StoryDto>>>
    {
        public int EpicId { get; set; }

        public GetStoriesByEpicIdQuery(int epicId)
        {
            EpicId = epicId;
        }
    }
}
