using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.SprintDetails.Query
{
    public class GetSprintsByProjectIdQueryHandler : IRequestHandler<GetSprintsByProjectIdQuery, ResponseDto<IEnumerable<SprintDto>>>
    {
        private readonly ISprintRepository _sprintRepository;
        private readonly IMapper _mapper;

        public GetSprintsByProjectIdQueryHandler(ISprintRepository sprintRepository, IMapper mapper)
        {
            _sprintRepository = sprintRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<IEnumerable<SprintDto>>> Handle(GetSprintsByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var sprints = await _sprintRepository.GetSprintsByProjectIdAsync(request.ProjectId);
            var sprintDtos = _mapper.Map<IEnumerable<SprintDto>>(sprints);
            return ResponseDto<IEnumerable<SprintDto>>.SuccessResponse(sprintDtos);
        }
    }
}

