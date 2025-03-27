using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.EpicDetails.Command
{
    public class DeleteEpicCommand : IRequest<ResponseDto<bool>>
    {
        public int Id { get; set; }

        public DeleteEpicCommand(int id)
        {
            Id = id;
        }
    }
}
