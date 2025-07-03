using AutoMapper;
using MediatR;
using ProjectManagement.Application.Dto;
using ProjectManagement.Core.Entities;
using ProjectManagement.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagement.Application.UseCases.StoryDetails.Command
{
    public class UpdateStoryCommandHandler : IRequestHandler<UpdateStoryCommand, ResponseDto<StoryDto>>
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStoryCommandHandler(IStoryRepository storyRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _storyRepository = storyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<StoryDto>> Handle(UpdateStoryCommand request, CancellationToken cancellationToken)
        {
            var existingStory = await _storyRepository.GetStoryByIdAsync(request.Id);
            if (existingStory == null)
            {
                return ResponseDto<StoryDto>.ErrorResponse("Story not found", 404);
            }

            existingStory.Title = request.Title;
            existingStory.Description = request.Description;
            existingStory.EpicId = request.EpicId;

            var updatedStory = await _storyRepository.UpdateStoryAsync(existingStory);
            await _unitOfWork.SaveChangesAsync();

            var storyDto = _mapper.Map<StoryDto>(updatedStory);
            return ResponseDto<StoryDto>.SuccessResponse(storyDto);
        }
    }
}
