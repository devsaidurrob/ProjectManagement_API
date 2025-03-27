using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.TaskItemDetails.Command
{
    public class DeleteTaskItemCommand : IRequest<ResponseDto<bool>>
    {
        public int Id { get; set; }

        public DeleteTaskItemCommand(int id)
        {
            Id = id;
        }
    }
}

