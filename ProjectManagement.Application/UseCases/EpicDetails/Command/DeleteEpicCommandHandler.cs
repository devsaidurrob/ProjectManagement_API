using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Infrastructure.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.EpicDetails.Command
{
    public class DeleteEpicCommandHandler : IRequestHandler<DeleteEpicCommand, ResponseDto<bool>>
    {
        private readonly IEpicRepository _epicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEpicCommandHandler(IEpicRepository epicRepository, IUnitOfWork unitOfWork)
        {
            _epicRepository = epicRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<bool>> Handle(DeleteEpicCommand request, CancellationToken cancellationToken)
        {
            var existingEpic = await _epicRepository.GetEpicByIdAsync(request.Id);
            if (existingEpic == null)
            {
                return ResponseDto<bool>.ErrorResponse("Epic not found", 404);
            }

            await _epicRepository.DeleteEpicAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();

            return ResponseDto<bool>.SuccessResponse(true);
        }
    }
}
