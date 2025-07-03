using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Entities;
using ProjectManagement.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.EpicDetails.Command
{
    public class UpdateEpicCommandHandler : IRequestHandler<UpdateEpicCommand, ResponseDto<EpicDto>>
    {
        private readonly IEpicRepository _epicRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEpicCommandHandler(IEpicRepository epicRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _epicRepository = epicRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<EpicDto>> Handle(UpdateEpicCommand request, CancellationToken cancellationToken)
        {
            var existingEpic = await _epicRepository.GetEpicByIdAsync(request.Id);
            if (existingEpic == null)
            {
                return ResponseDto<EpicDto>.ErrorResponse("Epic not found", 404);
            }

            existingEpic.Title = request.Title;
            existingEpic.Description = request.Description;
            existingEpic.ProjectId = request.ProjectId;

            var updatedEpic = await _epicRepository.UpdateEpicAsync(existingEpic);
            await _unitOfWork.SaveChangesAsync();

            var epicDto = _mapper.Map<EpicDto>(updatedEpic);
            return ResponseDto<EpicDto>.SuccessResponse(epicDto);
        }
    }
}
