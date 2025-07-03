using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.StoryDetails.Command
{
    public class DeleteStoryCommandHandler : IRequestHandler<DeleteStoryCommand, ResponseDto<bool>>
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStoryCommandHandler(IStoryRepository storyRepository, IUnitOfWork unitOfWork)
        {
            _storyRepository = storyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<bool>> Handle(DeleteStoryCommand request, CancellationToken cancellationToken)
        {
            var existingStory = await _storyRepository.GetStoryByIdAsync(request.Id);
            if (existingStory == null)
            {
                return ResponseDto<bool>.ErrorResponse("Story not found", 404);
            }

            await _storyRepository.DeleteStoryAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();

            return ResponseDto<bool>.SuccessResponse(true);
        }
    }
}
