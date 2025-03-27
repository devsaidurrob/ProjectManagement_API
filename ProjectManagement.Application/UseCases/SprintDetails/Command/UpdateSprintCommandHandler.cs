using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Entities;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.SprintDetails.Command
{
    public class UpdateSprintCommandHandler : IRequestHandler<UpdateSprintCommand, ResponseDto<SprintDto>>
    {
        private readonly ISprintRepository _sprintRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSprintCommandHandler(ISprintRepository sprintRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _sprintRepository = sprintRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<SprintDto>> Handle(UpdateSprintCommand request, CancellationToken cancellationToken)
        {
            var existingSprint = await _sprintRepository.GetSprintByIdAsync(request.Id);
            if (existingSprint == null)
            {
                return ResponseDto<SprintDto>.ErrorResponse("Sprint not found", 404);
            }

            existingSprint.Name = request.Name;
            existingSprint.StartDate = request.StartDate;
            existingSprint.EndDate = request.EndDate;
            existingSprint.ProjectId = request.ProjectId;

            var updatedSprint = await _sprintRepository.UpdateSprintAsync(existingSprint);
            await _unitOfWork.SaveChangesAsync();

            var sprintDto = _mapper.Map<SprintDto>(updatedSprint);
            return ResponseDto<SprintDto>.SuccessResponse(sprintDto);
        }
    }
}

