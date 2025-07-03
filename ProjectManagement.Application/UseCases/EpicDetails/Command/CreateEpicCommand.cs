using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.EpicDetails.Command
{
    public class CreateEpicCommand : IRequest<ResponseDto<EpicDto>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }

    }
}
