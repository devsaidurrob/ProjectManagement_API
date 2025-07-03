using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.EpicDetails.Query
{
    public class GetAllEpicsQueryHandler : IRequestHandler<GetAllEpicsQuery, ResponseDto<IEnumerable<EpicDto>>>
    {
        private readonly IEpicRepository _epicRepository;
        private readonly IMapper _mapper;

        public GetAllEpicsQueryHandler(IEpicRepository epicRepository, IMapper mapper)
        {
            _epicRepository = epicRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<IEnumerable<EpicDto>>> Handle(GetAllEpicsQuery request, CancellationToken cancellationToken)
        {
            var epics = await _epicRepository.GetAllEpicsAsync();
            var epicDtos = _mapper.Map<IEnumerable<EpicDto>>(epics);
            return ResponseDto<IEnumerable<EpicDto>>.SuccessResponse(epicDtos);
        }
    }
}
