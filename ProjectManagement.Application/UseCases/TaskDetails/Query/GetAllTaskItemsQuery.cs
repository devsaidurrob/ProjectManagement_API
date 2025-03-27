using MediatR;
using ProjectManagement.Application.Dto;
using System.Collections.Generic;

namespace ProjectManagement.Application.UseCases.TaskItemDetails.Query
{
    public class GetAllTaskItemsQuery : IRequest<ResponseDto<IEnumerable<TaskItemDto>>>
    {
    }
}

