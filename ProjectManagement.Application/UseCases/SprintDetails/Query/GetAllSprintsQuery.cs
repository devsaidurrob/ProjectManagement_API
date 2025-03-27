using MediatR;
using ProjectManagement.Application.Dto;
using System.Collections.Generic;

namespace ProjectManagement.Application.UseCases.SprintDetails.Query
{
    public class GetAllSprintsQuery : IRequest<ResponseDto<IEnumerable<SprintDto>>>
    {
    }
}

