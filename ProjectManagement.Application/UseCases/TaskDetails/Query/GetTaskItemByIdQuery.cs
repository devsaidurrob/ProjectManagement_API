using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.TaskItemDetails.Query
{
    public class GetTaskItemByIdQuery : IRequest<ResponseDto<TaskItemDto>>
    {
        public int Id { get; set; }

        public GetTaskItemByIdQuery(int id)
        {
            Id = id;
        }
    }
}

