using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Entities;
using ProjectManagement.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.SprintDetails.Command
{
    public class CreateSprintCommandHandler : IRequestHandler<CreateSprintCommand, ResponseDto<SprintDto>>
    {
        private readonly ISprintRepository _sprintRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSprintCommandHandler(ISprintRepository sprintRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _sprintRepository = sprintRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<SprintDto>> Handle(CreateSprintCommand request, CancellationToken cancellationToken)
        {
            var sprint = _mapper.Map<Sprint>(request);
            var addedSprint = await _sprintRepository.AddSprintAsync(sprint);
            await _unitOfWork.SaveChangesAsync();
            var sprintDto = _mapper.Map<SprintDto>(addedSprint);
            return ResponseDto<SprintDto>.SuccessResponse(sprintDto);
        }
    }
}

