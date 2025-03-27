using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.SprintDetails.Query
{
    public class GetSprintByIdQueryHandler : IRequestHandler<GetSprintByIdQuery, ResponseDto<SprintDto>>
    {
        private readonly ISprintRepository _sprintRepository;
        private readonly IMapper _mapper;

        public GetSprintByIdQueryHandler(ISprintRepository sprintRepository, IMapper mapper)
        {
            _sprintRepository = sprintRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<SprintDto>> Handle(GetSprintByIdQuery request, CancellationToken cancellationToken)
        {
            var sprint = await _sprintRepository.GetSprintByIdAsync(request.Id);
            if (sprint == null)
            {
                return ResponseDto<SprintDto>.ErrorResponse("Sprint not found", 404);
            }
            var sprintDto = _mapper.Map<SprintDto>(sprint);
            return ResponseDto<SprintDto>.SuccessResponse(sprintDto);
        }
    }
}

