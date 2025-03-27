using MediatR;
using ProjectManagement.Application.Dto;
using System.Collections.Generic;

namespace ProjectManagement.Application.UseCases.EpicDetails.Query
{
    public class GetAllEpicsQuery : IRequest<ResponseDto<IEnumerable<EpicDto>>>
    {
    }
}
