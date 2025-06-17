using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.EpicDetails.Query
{
    public class GetEpicsByProjectIdQueryHandler : IRequestHandler<GetEpicsByProjectIdQuery, ResponseDto<IEnumerable<EpicDto>>>
    {
        private readonly IEpicRepository _epicRepository;
        private readonly IMapper _mapper;

        public GetEpicsByProjectIdQueryHandler(IEpicRepository epicRepository, IMapper mapper)
        {
            _epicRepository = epicRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<IEnumerable<EpicDto>>> Handle(GetEpicsByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var epics = await _epicRepository.GetEpicsByProjectIdAsync(request.ProjectId);
            var epicDtos = _mapper.Map<IEnumerable<EpicDto>>(epics);
            return ResponseDto<IEnumerable<EpicDto>>.SuccessResponse(epicDtos);
        }
    }
}
