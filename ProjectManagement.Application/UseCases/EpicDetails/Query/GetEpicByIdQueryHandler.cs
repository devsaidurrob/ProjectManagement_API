using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.EpicDetails.Query
{
    public class GetEpicByIdQueryHandler : IRequestHandler<GetEpicByIdQuery, ResponseDto<EpicDto>>
    {
        private readonly IEpicRepository _epicRepository;
        private readonly IMapper _mapper;

        public GetEpicByIdQueryHandler(IEpicRepository epicRepository, IMapper mapper)
        {
            _epicRepository = epicRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<EpicDto>> Handle(GetEpicByIdQuery request, CancellationToken cancellationToken)
        {
            var epic = await _epicRepository.GetEpicByIdAsync(request.Id);
            if (epic == null)
            {
                return ResponseDto<EpicDto>.ErrorResponse("Epic not found", 404);
            }
            var epicDto = _mapper.Map<EpicDto>(epic);
            return ResponseDto<EpicDto>.SuccessResponse(epicDto);
        }
    }
}
