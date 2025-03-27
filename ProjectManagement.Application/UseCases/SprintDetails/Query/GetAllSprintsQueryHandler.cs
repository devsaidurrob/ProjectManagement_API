using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.SprintDetails.Query
{
    public class GetAllSprintsQueryHandler : IRequestHandler<GetAllSprintsQuery, ResponseDto<IEnumerable<SprintDto>>>
    {
        private readonly ISprintRepository _sprintRepository;
        private readonly IMapper _mapper;

        public GetAllSprintsQueryHandler(ISprintRepository sprintRepository, IMapper mapper)
        {
            _sprintRepository = sprintRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<IEnumerable<SprintDto>>> Handle(GetAllSprintsQuery request, CancellationToken cancellationToken)
        {
            var sprints = await _sprintRepository.GetAllSprintsAsync();
            var sprintDtos = _mapper.Map<IEnumerable<SprintDto>>(sprints);
            return ResponseDto<IEnumerable<SprintDto>>.SuccessResponse(sprintDtos);
        }
    }
}

