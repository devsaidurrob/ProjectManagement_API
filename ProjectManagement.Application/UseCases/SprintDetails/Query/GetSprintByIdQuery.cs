using MediatR;
using ProjectManagement.Application.Dto;

namespace ProjectManagement.Application.UseCases.SprintDetails.Query
{
    public class GetSprintByIdQuery : IRequest<ResponseDto<SprintDto>>
    {
        public int Id { get; set; }

        public GetSprintByIdQuery(int id)
        {
            Id = id;
        }
    }
}

