using MediatR;
using ProjectManagement.Application.Dto;
using System.Collections.Generic;

namespace ProjectManagement.Application.UseCases.TaskItemDetails.Query
{
    public class GetTaskItemsByStoryIdQuery : IRequest<ResponseDto<IEnumerable<TaskItemDto>>>
    {
        public int StoryId { get; set; }

        public GetTaskItemsByStoryIdQuery(int storyId)
        {
            StoryId = storyId;
        }
    }
}

