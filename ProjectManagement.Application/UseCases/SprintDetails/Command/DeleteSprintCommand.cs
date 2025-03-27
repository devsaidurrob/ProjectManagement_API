using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.SprintDetails.Command
{
    public class DeleteSprintCommand : IRequest<ResponseDto<bool>>
    {
        public int Id { get; set; }

        public DeleteSprintCommand(int id)
        {
            Id = id;
        }
    }
}

