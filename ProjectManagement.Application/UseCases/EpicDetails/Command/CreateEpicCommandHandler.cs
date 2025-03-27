using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.EpicDetails.Command
{
    public class CreateEpicCommandHandler : IRequestHandler<CreateEpicCommand, ResponseDto<EpicDto>>
    {
        private readonly IEpicRepository _epicRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateEpicCommandHandler(IEpicRepository epicRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _epicRepository = epicRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<EpicDto>> Handle(CreateEpicCommand request, CancellationToken cancellationToken)
        {
            var epic = _mapper.Map<Epic>(request);
            var addedEpic = await _epicRepository.AddEpicAsync(epic);
            await _unitOfWork.SaveChangesAsync();
            var epicDto = _mapper.Map<EpicDto>(addedEpic);
            return ResponseDto<EpicDto>.SuccessResponse(epicDto);
        }
    }
}
