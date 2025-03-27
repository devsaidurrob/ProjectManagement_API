using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.EpicDetails.Query
{
    public class GetEpicByIdQuery : IRequest<ResponseDto<EpicDto>>
    {
        public int Id { get; set; }

        public GetEpicByIdQuery(int id)
        {
            Id = id;
        }
    }
}
